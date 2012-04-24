<html>



<BODY BACKGROUND="./headerback.gif" BGCOLOR="#ffffff" MARGINWIDTH="0" MARGINHEIGHT="0" TOPMARGIN="0" LEFTMARGIN="0" TEXT="#FFFFFF">

<TABLE WIDTH="100%" HEIGHT="70" BACKGROUND="headerback.gif" CELLSPACING="0" CELLPADDING="0" BORDER="0">
	<TR><TD ALIGN="left"><IMG SRC="header2.jpg" WIDTH="760" HEIGHT="134" BORDER="0" ALT="Major Drilling Group International Inc."></TD></TR>
</TABLE>
<TABLE WIDTH="100%" HEIGHT="1" BGCOLOR="#ffffff" CELLSPACING="0" CELLPADDING="0" BORDER="0">
	<TR><TD ALIGN="left"><IMG SRC="spacer.gif" WIDTH="760" HEIGHT="1" BORDER="0" ALT=""></TD></TR>
</TABLE>


<?php

	//DB CONNECTION CODE
	$connect = odbc_connect("wireline", "wireline_user", "w1reline");
	if( $connect == 0 ) {  //Note that the the php server has to be connected to the CheckPoint VPN in order to access to the Major DB.
	    // Error reporting/handling here.
	    echo "ERROR CONNECTING TO DB";
	}
	else{
		//DB CONNECTION SUCCESS
		
		$drillid = $_POST["drillid"];
		$country = $_POST["country"];
		$speed = $_POST["speed"];
		$force = $_POST["force"];
		$oldDrillID = $_POST["oldDrillID"];
		$oldCountry = $_POST["oldCountry"];
		$newCountryCode = $_GET['NewCountryCode'];

		//Create JS variables for default page load values
		echo '<script>';
		echo 'var defaultDrillid = \'' . $drillid . '\';';
		echo 'var defaultCountry = \'' . $country . '\';';
		echo 'var defaultSpeed = \'' . $speed . '\';';
		echo 'var defaultForce = \'' . $force . '\';';
		echo '</script>';
		
		//Look to see if this comes from the AddCountry functionality		
		if($newCountryCode != ""){
			
			//Code to save the new country code
			$query = "insert into dbo.country Values('" . $_GET['NewCountryCode'] . "')";
			$result = odbc_exec($connect, $query);
			echo '<script> var addCountrySuccessFlag = "visible"; </script> ';
		}	
		else{
			echo '<script> var addCountrySuccessFlag = "invisible"; </script> ';
		
			if($country != ""){
				
				if($drillid == ""){
					//Code to update the wireline_monitor by country
					$query = "update dbo.wireline_monitor set opt_sp = '" . $speed . "', opt_frc = '" . $force . "' where country = '" . $country . "' ";
					$result = odbc_exec($connect, $query);
				}
				else{
					//Code to update the wireline_monitor table by drill id
					$query = "update dbo.wireline_monitor set rig_id = '" . $drillid . "', country = '" . $country . "', opt_sp = '" . $speed . "', opt_frc = '" . $force . "' where rig_id = '" . $oldDrillID . "' ";
					$result = odbc_exec($connect, $query);
				}
				//flag variable to tell JS to show the success message
				echo '<script> var updateRecordSuccessFlag = "visible"; </script> ';
			}	
			else{
				//flag variable to tell JS to not show the success message
				echo '<script> var updateRecordSuccessFlag = "invisible"; </script> ';
			}
		}		
		
		//Get the data from the wireline_monitor table				
		$query = "SELECT * FROM dbo.wireline_monitor";
		$result = odbc_exec($connect, $query);
		echo '<form>';
		
		//hidden form elements to keep older values
		echo '<input type="hidden" name="oldDrillID" value="" />';
		echo '<input type="hidden" name="oldCountry" value="" />';
		
		echo '<script type="text/javascript" language="javascript">';
		echo "\n";
		echo 'var elementsArray =  new Array()   ;';
		echo "\n";
		$i = 0;
				
		while(odbc_fetch_row($result)){ 
			
			//loop thru the records and put them in a JS array
			$drillid = trim(odbc_result($result, 1)); 
			$country = trim(odbc_result($result, 2)); 
			$speed = trim(odbc_result($result, 3)); 
			$force = trim(odbc_result($result, 4)); 

			echo "\n";
			echo 'elementsArray[' . $i . '] = new Array(4);';
			//drill id
			echo 'elementsArray[' . $i . '][0] = "' . $drillid . '";'; echo "\n";
			//country
			echo 'elementsArray[' . $i . '][1] = "' . $country . '";'; echo "\n";
			//speed
			echo 'elementsArray[' . $i . '][2] = "' . $speed . '";'; echo "\n";			 
			//force
			echo 'elementsArray[' . $i . '][3] = "' . $force . '";'; echo "\n";	
			
			echo "\n";					
									
			$i++;			
		}
		
		//Get the country list from the countries table
		$query = "SELECT distinct country FROM dbo.country";
		$result = odbc_exec($connect, $query);

		//Put the countries in a JS array		
		$i = 0;
		echo 'var countriesArray =  new Array()   ;';
		while(odbc_fetch_row($result)){ 

			//loop thru the records.
			$countrycode = trim(odbc_result($result, 1)); 
			echo 'countriesArray[' . $i . '] = "' . $countrycode . '";'; echo "\n";
			
			$i++;
		}		
		
		echo '</script>'; 
	}	
	
			//Print out barebone HTML form elements
			echo '</br></br><table align="center">'; 
			
			echo '<tr><td colspan="2" align="center"> Wireline Optimal Speed Interface  </td></tr>';
			echo '<tr><td colspan="2" align="center"> <div id="divSuccess" >  </div>  </br></br> </td></tr>';
			
			echo '<tr><td>';
			echo '<table><tr>';
			echo '<td align="left">Drill Id:</td>';
			echo '<td align="right"><select id="drillid" name="drillid" width="100%" STYLE="width: 300px" onchange="modifyResults(this);">';
			echo '<option value=""></option>';
			echo '</option>';
			echo '</select>';	
			echo '</td></tr>';
			
			echo '<tr>';
			echo '<td align="left">Country:</td>';
			echo '<td align="right"><select id="country" name="country" width="100%" STYLE="width: 300px">';
			echo '<option value=""></option>';
			echo '</option>';
			echo '</select>';
			echo '</td></tr>';
			
			echo '<tr>';
			echo '<td align="left">Speed:</td>';
			echo '<td  align="right">';
			echo '<input type="text" id="speed" name="speed">';
			echo '</td></tr>';
			
			echo '<tr>';
			echo '<td align="left">Force:</td>';
			echo '<td align="right">'; 
			echo '<input type="text" id="force" name="force">'; 
			echo '</td></tr>';
			
			echo '<tr><td></br></br>';
			echo ' <table><tr><td>  <button onclick="UpdateRecord();" > Submit </button></td>   <td>  <button onclick="addCountry();" > Add a Country </button> </td> ';
			
			echo '</tr></table>';
			echo '</td></tr>';
			
			echo '</table>';
			
			echo '</td></tr></table>';
?>


<script type="text/javascript" language="javascript">

	// This function loads the default form element values before the user sees the screen
	function loadPageValues(){

		var drillidRequest = "<?php echo $_GET["drillid"]; ?>";
		var valueinRequest = false;
		
		if(drillidRequest != ""){
			valueinRequest = true;
		}
				
		//Get the form element handles		
		var drillidCombo = document.getElementById('drillid');
		var countryCombo = document.getElementById('country');
		var speedTextBox = document.getElementById('speed');
		var forceTextBox = document.getElementById('force');
		
		//Loop thru the array data and create the combo box option values		
		for(var i = 0; i < elementsArray.length; i++){
			
			var optn = document.createElement("OPTION");
			optn.text = elementsArray[i][0];
			optn.value = elementsArray[i][0];
			
			//Selected value if it's in the _POST
			//if(defaultDrillid == elementsArray[i][0]){
			if (drillidRequest == elementsArray[i][0]){				
				optn.selected = 'true';
			}
			drillidCombo.options.add(optn);	
		}
		
		for(var b = 0; b < countriesArray.length; b++){

			//Grab the values from the countriesArray
			var optn = document.createElement("OPTION");
			optn.text = countriesArray[b];
			optn.value = countriesArray[b];
			
			//Selected value if it's in the _POST
			if(defaultCountry == countriesArray[b]){
				optn.selected = 'true';
			}
			
			countryCombo.options.add(optn);	
		}
		
		speedTextBox.value = defaultSpeed;
		forceTextBox.value = defaultForce;
		
		//Get the handle on the div element		
		var div = document.getElementById('divSuccess');
		
		//** New Country Saved Successfully **
		if(typeof addCountrySuccessFlag != "undefined"){ //in case the variable doesn't exist.
			if(addCountrySuccessFlag == 'visible'){
				div.style.display = "block";
				div.innerHTML = "** New Country Saved Successfully **";
			}
			else{
				div.style.display = "none";
			}
		}		
		
		//** Record Updated Successfully **
		if(typeof updateRecordSuccessFlag != "undefined"){ //in case the variable doesn't exist.
			if(updateRecordSuccessFlag == 'visible'){
				div.style.display = "block";
				div.innerHTML = "** Record Updated Successfully **";
			}
			else{
				div.style.display = "none";
			}
		}
		
		if(valueinRequest){
			modifyResults(drillidCombo);
		}

	}

	//This function changes the country, speed and force values based on the drill id chosen by the user
	function modifyResults(comboBox){
		
		//Get the handle on the form elements
		var countryCombo = document.getElementById('country');
		var speedTextBox = document.getElementById('speed');
		var forceTextBox = document.getElementById('force');
		
		//Find the values that we need to display for the user
		if(comboBox.options[comboBox.selectedIndex].value != ""){
			var countryComparing = elementsArray[comboBox.selectedIndex-1][1];
			var selectedIndex = comboBox.selectedIndex;
	
			//Find the index of the country we're trying to find in the countries drop down box
			for(var b = 0 ; b < countryCombo.length ; b++){
				if(countryCombo.options[b].value == countryComparing){
					countryCombo.options[b].selected = true;	
				}	
			}
			
			speedTextBox.value = elementsArray[comboBox.selectedIndex-1][2];
			forceTextBox.value = elementsArray[comboBox.selectedIndex-1][3];
		}
		else{
			//If the user chose the blank value in the combo box, we want to clear the values of the rest of the elements		
			countryCombo.selectedIndex = 0;
			speedTextBox.value = '';
			forceTextBox.value = '';
				
		}
	}
	
	function addCountry(){
		//Code to add a country to the country table
		window.open('./addCountry.htm', null, "height=50,width=300,status=no,toolbar=no,menubar=no,location=no");
	}
	
	function saveNewCountry(newCountryValue){
		//call the index.php page and subit the form values

		var queryString = "index.php?NewCountryCode=" + newCountryValue;
		document.forms[0].method = "post";
		document.forms[0].action = queryString;
		document.forms[0].submit();
		
	}
	
	function UpdateRecord(){

		//If the Country, Speed and Force values are not filled in, we don't want to submit
		var countryCombo = document.getElementById('country');
		var speedTextBox = document.getElementById('speed');
		var forceTextBox = document.getElementById('force');
		
		if(countryCombo.options[countryCombo.selectedIndex].value == "" || speedTextBox.value == "" || forceTextBox.value == ""){
			alert('Country, Speed and Force are required input values');
			return;	
		}
		else if (!IsNumeric(speedTextBox.value) || !IsNumeric(forceTextBox.value)){
			alert('Speed and Force must be numeric values');
			return;	
		}
				
		//Fill out the hidden field elements
		document.getElementById("oldDrillID").value = document.getElementById('drillid').value;
		document.getElementById("oldCountry").value = document.getElementById('country').value;

		//call the index.php page and submit the form elements	
		var queryString = "index.php";
		document.forms[0].method = "post";
		document.forms[0].action = queryString;
		document.forms[0].submit();
	}

	//  check for valid numeric strings	
	function IsNumeric(strString){
		var strValidChars = "0123456789.-";
		var strChar;
		var blnResult = true;
		
		//  test strString consists of valid characters listed above		
		if (strString.length == 0){ 
			return false;
		}

		for (i = 0; i < strString.length && blnResult == true; i++){
			strChar = strString.charAt(i);
			if (strValidChars.indexOf(strChar) == -1){
				blnResult = false;
			}
		}
		return blnResult;
	}
</script>


	<script>
		//Initialize the page values
		loadPageValues();
	</script>

</form>
</html>