<?php

require_once 'xmlrpc/lib/xmlrpc.inc';
require_once 'fridge_sdb.php';

$rpc_key = 'c0701883da4d00b2d48723c8fa54d51008b32132';  // Set your rpc_key here
$json_key = '5cd62861daf5efb419c545116b0f6b31';

switch ($_GET['action'])
{

  case "lock":

    write_lock($_GET["val"]);

    $arr = array('status' => 'lock' . $_GET["val"]);
    echo json_encode($arr);
    break;

  case "milk":

    write_milk($_GET["val"]);

    $sdb = new AmazonSDB();
    $lock_status = sdb_fridge_get_lock($sdb);

    $arr = array('status' => 'lock' . $lock_status);
    echo json_encode($arr);
    break;

  case "upc":

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
    echo $_GET['val'];
    write_upc($_GET['val'], $name, "");

    break;

  default:

    $sdb = new AmazonSDB();
    $items = sdb_fridge_get_items($sdb);

    // Re-structure the data so access is easier (see helper function below)
    $data = reorganize_data($items);

    // Generate <table> HTML from the data (see helper function below)
    $item_html = generate_html_table($data);

    $milk = sdb_fridge_get_milk($sdb);
    
    $lock = sdb_fridge_get_lock($sdb);

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

    $html = "<center><span class='milk'><b>Fridge is: <i>${lock_text}</i></b></span><br>${lock_link}<br><br><span class='milk'><b>Milk: ${milk}</b></span></center><br><br></center>" . $item_html;
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


