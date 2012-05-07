<?php

if ($_GET["w"])
{
	$arr = array('status' => 0);
}
else
{
	$arr = array('a' => 1, 'b' => 2, 'c' => 3, 'd' => 4, 'e' => 5);
}
echo json_encode($arr);
?>
