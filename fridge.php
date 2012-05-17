<?php

require_once 'xmlrpc/lib/xmlrpc.inc';
$rpc_key = 'c0701883da4d00b2d48723c8fa54d51008b32132';  // Set your rpc_key here


switch ($_GET['action'])
{

  case "milk":

    write_milk($_GET["val"]);

    $arr = array('status' => 'ok');
    echo json_encode($arr);
    break;

  case "upc":

    //$arr = array('status' => 'ok');
    //echo json_encode($arr);

    $server = new xmlrpc_client('/xmlrpc', 'www.upcdatabase.com');

    $message = new xmlrpcmsg('lookup',
                array( new xmlrpcval( array(
                        'rpc_key' => new xmlrpcval($rpc_key, 'string'),
                        'upc' => new xmlrpcval($_GET['val'], 'string'),
                ), 'struct'))
    );
    $resp = $server->send($message);

    //If there was a problem sending the message, the resp will be false
    if (!$resp)
    {
       //print the error code from the client and exit
       echo 'Communication error: ' . $client->errstr;
       exit;
    }

    //If the response doesn't have a fault code, show the response as the array it is
    if(!$resp->faultCode())
    {
                //Store the value of the response in a variable
                $val = $resp->value();
                //Decode the value, into an array.
                $data = $val; //XML_RPC_decode($val);
                //Optionally print the array to the screen to inspect the values
                echo "<pre>" . print_r($data, true) . "</pre>";

    }else{
                //If something went wrong, show the error
                echo 'Fault Code: ' . $resp->faultCode() . "\n";
                echo 'Fault Reason: ' . $resp->faultString() . "\n";
    }

    write_upc($_GET["val"]);
    echo "Write UPC.";
    break;

  default:

    $handle = fopen("/tmp/upc.txt", "r");
    while ($buf = fgets($handle, 4096)) {
      echo $buf;
      echo "<br>";
    }
    fclose($handle);

    break;
}

function write_milk($weight)
{
    $myFile = "/tmp/weight.txt";
    $fh = fopen($myFile, 'w') or die("can't open file");
    $stringData = $weight;
    fwrite($fh, $stringData);
    fclose($fh);
}

function write_upc($upc)
{
    $myFile = "/tmp/upc.txt";
    $fh = fopen($myFile, 'w') or die("can't open file");
    $stringData = $upc;
    fwrite($fh, $stringData);
    fwrite($fh, "\n");
    fclose($fh);
}

?>
