<?php

//AKIAI7NLYCLTK32TBMMA
//LJcIPJbfqtpAHowAYavMVuddTs3IVsjnltnVx6pT

/*%******************************************************************************************%*/
// SETUP

	// Enable full-blown error reporting. http://twitter.com/rasmus/status/7448448829
	error_reporting(-1);

	// Set HTML headers
	header("Content-type: text/html; charset=utf-8");

	// Include the SDK
	require_once 'sdk-1.5.4/sdk.class.php';

/*%******************************************************************************************%*/

// Data Functions
function sdb_fridge_create_domain($_sdb,$sDomain)
{
	// Create the domain
	$new_domain = $_sdb->create_domain($sDomain);

	// Was the domain created successfully?
	return $new_domain->isOK();
}

function sdb_fridge_set_lock($_sdb,$val)
{
	$domain = "undercurrent.fridge.lock";

	$_sdb->delete_attributes($domain, "lock");
		
        $add_attributes = $_sdb->batch_put_attributes($domain, array(
				"lock" => array(
					'open' => $val
				)	
			)
		);
}

function sdb_fridge_get_fitbit($_sdb)
{
	$domain = "undercurrent.fridge.fitbit";

	$results = $_sdb->select("SELECT * FROM `{$domain}` WHERE ItemName()='fitbit'");
	$items = $results->body->Item();

        if ($items[0])
        {
	  return $items[0];
        }
        return null;
}

function sdb_fridge_set_fitbit($_sdb,$status,$token="",$secret="",$state="",$calorie_limit="")
{
	$domain = "undercurrent.fridge.fitbit";

	$_sdb->delete_attributes($domain, "fitbit");
		
        $add_attributes = $_sdb->batch_put_attributes($domain, array(
				"fitbit" => array(
					'token' => $token,
					'secret' => $secret,
					'state' => $state,
					'calorie_limit' =>  $calorie_limit,
					'status' => $status
				)
			)
		);
}

function sdb_fridge_set_milk($_sdb,$weight)
{
	$domain = "undercurrent.fridge.milk";

	$_sdb->delete_attributes($domain, "milk");
		
        $add_attributes = $_sdb->batch_put_attributes($domain, array(
				"milk" => array(
				'weight' => $weight
				)	
			)
		);
}

function sdb_fridge_add_history($_sdb,$sUpc,$sName,$sDesc,$sAction)
{

	$domain = "undercurrent.fridge.history";

	$add_attributes = $_sdb->batch_put_attributes($domain, array(
			time() => array(
				'upc' => $sUpc,
				'name' => $sName,
				'description' => $sDesc,
				'action' => $sAction,
				'time' => date(DATE_RFC822)
			)	
		)
	);
}

function sdb_fridge_get_lock($_sdb)
{
	$domain = "undercurrent.fridge.lock";

	$results = $_sdb->select("SELECT open FROM `{$domain}` WHERE ItemName()='lock'");
	$items = $results->body->Item();

        if ($items[0])
        {
		$open =  $items[0]->Attribute[0]->Value;
        }

	return $open;
}

function sdb_fridge_get_milk($_sdb)
{
	$raw_weight = 0;

	$domain = "undercurrent.fridge.milk";

	$results = $_sdb->select("SELECT weight FROM `{$domain}` WHERE ItemName()='milk'");
	$items = $results->body->Item();

        if ($items[0])
        {
		$raw_weight =  $items[0]->Attribute[0]->Value;
        }

        if ($raw_weight > 875)
	{
	  $weight = "Full";
	} else if ($raw_weight > 850) {
	  $weight = "88.5%";
	} else if ($raw_weight > 820) {
	  $weight = "75%";
	} else if ($raw_weight > 785) {
	  $weight = "62.5%";
	} else if ($raw_weight > 745) {
	  $weight = "50%";
	} else if ($raw_weight > 675) {
	  $weight = "38.5%";
	} else if ($raw_weight > 525) {
	  $weight = "25%";
	} else if ($raw_weight > 300) {
	  $weight = "Almost Empty";
	} else {
	  $weight = "<i>Removed</i>";
	}
	return $weight;
}

function sdb_fridge_add_item($_sdb,$sUpc,$sName,$sDesc,$sAction)
{
	$domain = "undercurrent.fridge.item";

	if ($sAction == '2')
        {
		$add_attributes = $_sdb->batch_put_attributes($domain, array(
			$sUpc => array(
				'name' => $sName . " " . $sDesc,
				'count' => $count,
                                'date' => date(DATE_RFC822)
				)	
			)
		);
        } else {

           $results = $_sdb->select("SELECT date FROM `{$domain}` WHERE ItemName()='{$sUpc}'");
           $items = $results->body->Item();

           $att = $items[0]->Attribute[0];
           $attributes = Array('Name' => $att->Name, 'Value' => $att->Value);

	   $_sdb->delete_attributes($domain, $sUpc, $attributes);
        }
}

function sdb_fridge_get_history($_sdb)
{
	$domain = "undercurrent.fridge.history";

	$results = $_sdb->select("SELECT * FROM `{$domain}` WHERE action = 'Add' order by time");

	return $results->body->Item();
}


function sdb_fridge_get_items($_sdb)
{
	$domain = "undercurrent.fridge.item";

	$results = $_sdb->select("SELECT * FROM `{$domain}`");

	$items = $results->body->Item();

/*
        for ($i=0; $i<count($items); $i++)
        {
          $count = count($items[$i]->Attribute[3]);
          $items[$i]->Attribute[1].Value = $count;
        }
*/
        return $items;
}


	$sdb = new AmazonSDB();
        //$sdb->delete_domain('undercurrent.fridge.item');
	sdb_fridge_create_domain($sdb,'undercurrent.fridge.item');

/*%******************************************************************************************%*/
// HELPER FUNCTIONS

	function reorganize_data($items)
	{
		// Collect rows and columns
		$rows = array();
		$columns = array();

		foreach ($items as $item)
		{
			// Let's append to a new row
			$row = array();
			$row['id'] = (string) $item->Name;

			// Loop through the item's attributes
			foreach ($item->Attribute as $attribute)
			{
				// Store the column name
				$column_name = (string) $attribute->Name;

				// If it doesn't exist yet, create it.
				if (!isset($row[$column_name]))
				{
					$row[$column_name] = array();
				}

				// Append the new value to any existing values
				// (Remember: Entries can have multiple values)
				$row[$column_name][] = (string) $attribute->Value;
				natcasesort($row[$column_name]);

				// If we've not yet collected this column name, add it.
				if (!in_array($column_name, $columns, true))
				{
					$columns[] = $column_name;
				}
			}

			// Append the row we created to the list of rows
			$rows[] = $row;
		}

		// Return both
		return array(
			'columns' => $columns,
			'rows' => $rows,
		);
	}

        function sum_item_count(&$data)
        {

	   $rows = $data['rows'];

           for($i=0; $i<count($rows); $i++)
           {

             $count = count($rows[$i]['date']);
             $rows[$i]['count'][0] = $count;
             $rows[$i]['date'] = array($rows[$i]['date'][$count-1]);
           }
	   $data['rows'] = $rows;
        }

	function generate_html_table($data)
	{
		// Retrieve row/column data
		$columns = $data['columns'];
		$rows = $data['rows'];

		// Generate shell of HTML table
		$output = '<table cellpadding="0" cellspacing="0" border="0">' . PHP_EOL;
		$output .= '<thead>';
		$output .= '<tr>';
		$output .= '<th></th>'; // Corner of the table headers

		// Add the table headers
		foreach ($columns as $column)
		{
			$output .= '<th>' . $column . '</th>';
		}

		// Finish the <thead> tag
		$output .= '</tr>';
		$output .= '</thead>' . PHP_EOL;
		$output .= '<tbody>';

		// Loop through the rows
		foreach ($rows as $row)
		{
			// Display the item name as a header
			$output .= '<tr>' . PHP_EOL;
			$output .= '<th>' . $row['id'] . '</th>';

			// Pull out the data, in column order
			foreach ($columns as $column)
			{
				// If we have a value, concatenate the values into a string. Otherwise, nothing.
                                $index = count($row[$column]) - 1;
				//$output .= '<td>' . (isset($row[$column]) ? $row[$column][$index] : '') . '</td>';
				$output .= '<td>' . (isset($row[$column]) ? implode(', ', $row[$column]) : '') . '</td>';
			}
			$output .= '</tr>' . PHP_EOL;
		}

		// Close out our table
		$output .= '</tbody>';
		$output .= '</table>';

		return $output;
	}


function display_html($html)
{
?>
        <!DOCTYPE html>
        <html>
        <head>
                <meta http-equiv="Content-type" content="text/html; charset=utf-8">
                <title>sdb_create_domain_data</title>
                <style type="text/css" media="screen">
                body {
                        margin: 0;
                        padding: 0;
                        font: 14px/1.5em "Helvetica Neue", "Lucida Grande", Verdana, Arial, sans;
                        background-color: #fff;
                        color: #333;
                }
		.milk {

                        color: #333;
                        font: 25px/1.5em "Helvetica Neue", "Lucida Grande", Verdana, Arial, sans;
		}
                table {
                        margin: 50px auto 0 auto;
                        padding: 0;
                        border-collapse: collapse;
                }
                table th {
                        background-color: #eee;
                }
                table td,
                table th {
                        padding: 5px 10px;
                        border: 1px solid #eee;
                }
                table td {
                        border: 1px solid #ccc;
                }
                </style>

<script type="text/JavaScript">
<!--
function timedRefresh(timeoutPeriod) {
	//setTimeout("location.reload(true);",timeoutPeriod);
}
//   -->
</script>

        </head>
<body onload="">
	<?=$html?>
        </body>
        </html>

<?php
}
?>

