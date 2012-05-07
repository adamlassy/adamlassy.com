<?php

if ($_GET["action"] == "set")
{

$myFile = "/tmp/testFile.txt";
$fh = fopen($myFile, 'w') or die("can't open file");
$stringData = $_GET["val"];
fwrite($fh, $stringData);
fclose($fh);

$arr = array('status' => 'ok');
echo json_encode($arr);

}
else
{

$weight = 0;

$handle = fopen("/tmp/testFile.txt", "r");
if ($buf = fgets($handle, 4096)) {
  $weight = $buf;
}
fclose($handle);

  $arr = array('weight' => $weight);
  echo json_encode($arr);
}

?>
