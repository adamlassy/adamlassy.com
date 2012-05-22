<?php

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

function sdb_fridge_add_item($_sdb,$sUpc,$sName,$sDesc,$sAction)
{

	$domain = "undercurrent.fridge.item";

        $count = 0;

	$results = $_sdb->select("SELECT count FROM `{$domain}` WHERE ItemName()='{$sUpc}'");
	$items = $results->body->Item();
        if ($items[0])
        {
       		$count = (int) $items[0]->Attribute[0]->Value;

		$_sdb->delete_attributes($domain, $sUpc);
	}

	if ($sAction = 'Add') $count++;
	else $count--;

	if ($count > 0)
		$add_attributes = $_sdb->batch_put_attributes($domain, array(
				$sUpc => array(
				'name' => $sName,
				'description' => $sDesc,
				'count' => $count
				)	
			)
		);
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
	
	return $results->body->Item();
}


/*
// ADD DATA TO SIMPLEDB
	// Instantiate the AmazonSDB class
	$sdb = new AmazonSDB();

	//sdb_fridge_create_domain($sdb,'undercurrent.fridge.history');
	//sdb_fridge_create_domain($sdb,'undercurrent.fridge.item');

	sdb_fridge_add_history($sdb,"1234","Tic Tacs", "", "Add");

        sdb_fridge_add_item($sdb,"1234","Tic Tacs", "", "Add");

	$items = sdb_fridge_get_items($sdb);
        //$items = sdb_fridge_get_history($sdb);

echo "GOT ITEMS";

	// Re-structure the data so access is easier (see helper function below)
	$data = reorganize_data($items);

	// Generate <table> HTML from the data (see helper function below)
	$html = generate_html_table($data);
*/

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
        </head>
        <body>
	<?=$html?>
        </body>
        </html>

<?php
}
?>
