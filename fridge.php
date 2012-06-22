<?php

//require_once 'xmlrpc/lib/xmlrpc.inc';
require_once 'fridge_sdb.php';

$rpc_key = 'c0701883da4d00b2d48723c8fa54d51008b32132';  // Set your rpc_key here
$json_key = '5cd62861daf5efb419c545116b0f6b31';

switch ($_GET['action'])
{

  case "fitbit":

    $sdb = new AmazonSDB();
    
    $fitbit = sdb_fridge_get_fitbit($sdb);

    $state = $fitbit->Attribute[3]->Value;
    $token = $fitbit->Attribute[2]->Value;
    $secret = $fitbit->Attribute[4]->Value;
    $calorie_goal = $fitbit->Attribute[1]->Value;

    sdb_fridge_set_fitbit($sdb,$_GET["val"],$token,$secret,$state,$calorie_goal);
    break;

  case "lock":

    write_lock($_GET["val"]);

    $arr = array('status' => 'lock' . $_GET["val"]);
    echo json_encode($arr);
    break;

  case "milk":

    write_milk($_GET["val"]);

    $sdb = new AmazonSDB();

/*
    $fitbit = sdb_fridge_get_fitbit($sdb);
    $calories_out = get_calories($dat,$fitbit,$sdb);
    $calories_goal = $fitbit->Attribute[1]->Value;

    if ((int)$calories_out >= (int)$calories_goal)
    {
      $lock_status = 0;
      sdb_fridge_set_lock($sdb,$lock_status);
    }
    else
    {
      $lock_status = sdb_fridge_get_lock($sdb);
    }
*/

    $lock_status = sdb_fridge_get_lock($sdb);

    $arr = array('status' => 'lock' . $lock_status);
    echo json_encode($arr);
    break;

  case "upc":

    $name = "";

    switch ($_GET['val'])
    {
      case "08378354":
       $name = "Trader Joe's Lowfat Milk";
       break;
      case "076301580015":
       $name = "Apple Juice";
       break;
      case "051000000200":
       $name = "CAMPBELL SOUP COMPANY, 5.5 oz CAMPBELLS V-8 JUICE 6PK";
       break;
      case "048500001745":
       $name = "TROPICANA PRODUCTS, INC. 10 oz 100% Pure Orange Juice";
       break;
      case "048500008386":
       $name = "TROPICANA PRODUCTS, INC. 10 Fl Oz Cranberry Cocktail";
       break;
      case "180127000005":
       $name = "Zico pure coconut water";
       break;
      case "657622222015":
       $name = "16oz Honest Tea organic honey green tea";
       break;
      case "657622814043":
       $name = "16oz Honest Tea lemon tea";
       break;
    }


    if ($name == "")
    {
 
      $json_url = "http://www.upcdatabase.org/api/json/" . $json_key . "/" . $_GET['val'];
 
      // Initializing curl
      $ch = curl_init();

      // Configuring curl options
      curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
      curl_setopt($ch, CURLOPT_HTTPHEADER, 'Content-type: application/json');
      curl_setopt($ch, CURLOPT_URL, $json_url);

      // Getting results
      $result =  curl_exec($ch); // Getting jSON result string

      $result = json_decode($result, true);

      $name = "";
      if ($result['valid'] == true)
      {
        $name = $result['itemname'] . " " . $result['description'];
      }
    }
    write_upc($_GET['val'], $name, "");

    break;

  default:

    require_once 'fridge_fitbit.php';

    $sdb = new AmazonSDB();
    $items = sdb_fridge_get_items($sdb);

    // Re-structure the data so access is easier (see helper function below)
    $data = reorganize_data($items);

    //Sum up the item count
    sum_item_count($data);

    // Generate <table> HTML from the data (see helper function below)
    $item_html = generate_html_table($data);

    $milk = sdb_fridge_get_milk($sdb);
    
    $fitbit = sdb_fridge_get_fitbit($sdb);
    $fitbit_mode = $fitbit->Attribute[0]->Value;
    $calories_goal = $fitbit->Attribute[1]->Value;

    if ($_GET['calories']) { 
      $calories_goal = $_GET['calories'];
    
      $status = $fitbit->Attribute[0]->Value;
      $state = $fitbit->Attribute[3]->Value;
      $token = $fitbit->Attribute[2]->Value;
      $secret = $fitbit->Attribute[4]->Value;

      sdb_fridge_set_fitbit($sdb,$status,$token,$secret,$state,$calories_goal);
    }

    $dat = date('Y-m-d');
    $calories_out = get_calories($dat,$fitbit,$sdb);

    $lock = sdb_fridge_get_lock($sdb);
    
    if ($fitbit_mode == 0)
    {
      $fitbit_text = "Off";
      $fitbit_link = "<a href='fridge.php?action=fitbit&val=1'>fitbit mode on</a>";
    }
    else
    {

      if ((int)$calories_out >= (int)$calories_goal)
      {
        $lock = "0";
      }
      else
      {
        $lock = "1";
      }
      write_lock($lock);

      $fitbit_text = "On";
      $fitbit_link = "<a href='fridge.php?action=fitbit&val=0'>fitbit mode off</a>";
    }

    if ($lock == 0)
    {
      $lock_text = "Unlocked";
      $lock_link = "<a href='fridge.php?action=lock&val=1'>lock fridge</a>";
    }
    else
    {
      $lock_text = "Locked";
      $lock_link = "<a href='fridge.php?action=lock&val=0'>unlock fridge</a>";
    }

    $html = "<center>" .
"<span class='milk'><b>Fridge is: <i>${lock_text}</i></b></span><br>${lock_link}<br><br>" .
"<span class='milk'><b>Fitbit Mode: <i>${fitbit_text}</i></b><br>${calories_out} of ${calories_goal} Calories for {$dat}</span><br>${fitbit_link}<br><br>" .
"<span class='milk'><b>Milk: ${milk}</b></span></center><br><br>" . 
$item_html;

    display_html($html);

    break;
}

function write_lock($open)
{
    $sdb = new AmazonSDB();

    sdb_fridge_set_lock($sdb,$open);
}

function write_milk($weight)
{
    $sdb = new AmazonSDB();

    sdb_fridge_set_milk($sdb,$weight);
}

function write_upc($upc,$sProduct,$sDesc)
{
    $sdb = new AmazonSDB();

    $method = $_GET['in'];

    sdb_fridge_add_history($sdb, $upc, $sProduct, $sDesc, $method);
    sdb_fridge_add_item($sdb, $upc, $sProduct, $sDesc, $method);

}


?>

