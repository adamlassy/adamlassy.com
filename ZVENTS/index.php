<?php

	// Create a curl handle to a non-existing location
?>

<?

function search_str($api,$what,$cat="")
{
	$key = "FUKPPNUWOKOXTJSCYNBUKRJHEPUMAVGLXSTBCOGUFUJEUITWYBMOOWPONEPIEBLG";
	
	
	$data = "http://www.zvents.com/partner_rest/" . $api . "?key=" . $key . "&what=" . $what . "&where=San+Francisco";
		
	if ($cat != "")
	{
		$data .= "&cat=" . $cat;
	}

	return $data;
}

function objectsIntoArray($arrObjData, $arrSkipIndices = array())
{
    $arrData = array();
   
    // if input is object, convert into array
    if (is_object($arrObjData)) {
        $arrObjData = get_object_vars($arrObjData);
    }
   
    if (is_array($arrObjData)) {
        foreach ($arrObjData as $index => $value) {
            if (is_object($value) || is_array($value)) {
                $value = objectsIntoArray($value, $arrSkipIndices); // recursive call
            }
            if (in_array($index, $arrSkipIndices)) {
                continue;
            }
            $arrData[$index] = $value;
        }
    }
    return $arrData;
}

	if ($_POST && $_POST['search'] != "")
	{
		?>
		Results:
		<br><BR>
		<?


		//$arrXml = objectsIntoArray($xmlObj);
		
		?>
		<B>EVENTS</b>
		<br>
		<table border=0>
		<?
		
		//Events
		$data = search_str("search",$_POST['search']);
		print($data);
	
		$ch = curl_init($data);

		// Execute
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
		$xmlStr = curl_exec($ch);
		
		$xmlObj = simplexml_load_string($xmlStr);
		
		for ($i=0; $i<5; $i++)
		{
			?>
			<tr>
			<td><img width=90 src=<?=$xmlObj->event[$i]->images->url?>></td>
			<td><?=$xmlObj->event[$i]->name?></td>
			</tr>
			<?
		}

		?>
		</table>
		<Br><br>
		<B>VENUES</b>
		<br>
		<table border=0>
		<?
		for ($i=0; $i<5; $i++)
		{
			?>
			<tr>
			<td></td>
			<td><?=$xmlObj->venue[$i]->name?></td>
			</tr>
			<?
		}
		?>
		</table>
		<br><br>
		<B>PERFORMERS</b>
		<br>
		<table border=0>

		<?
		$data = search_str("search_for_performers",$_POST['search']);
		print($data);
	
		$ch = curl_init($data);

		// Execute
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
		$xmlStr = curl_exec($ch);
		
		$xmlObj = simplexml_load_string($xmlStr);
		
		for ($i=0; $i<5; $i++)
		{			
			if ($xmlObj->group[$i])
			{
			?>
			<tr>
			<td><img width=90 src=<?=$xmlObj->group[$i]->images->url?>></td>
			<td><?=$xmlObj->group[$i]->name?></td>
			</tr>
			<?
			}
		}
		?>
		</table>
		<br><br>
		<B>FILMS</b>
		<br>
		<table border=0>
		<?
		
		$data = search_str("search",$_POST['search'],62);
		print($data);
	
		$ch = curl_init($data);

		// Execute
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
		$xmlStr = curl_exec($ch);
		
		$xmlObj = simplexml_load_string($xmlStr);
		
		for ($i=0; $i<5; $i++)
		{
			if ($xmlObj->event[$i])
			{
			?>
			<tr>
			<td><img width=90 src=<?=$xmlObj->event[$i]->images->url?>></td>
			<td><?=$xmlObj->event[$i]->name?></td>
			</tr>
			<?
			}
		}
		
		?>
		</table>
		<?
	}
	else
	{
		?>

		<form method="POST" action="index.php">
		search: <input type="text" name="search"/><br>
		location: San Francisco<br>
		<input type="submit" />
		</form>

		<?
	}
?>
