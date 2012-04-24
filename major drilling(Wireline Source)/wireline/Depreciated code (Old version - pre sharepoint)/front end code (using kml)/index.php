<!-- 
	FLAT FILE READ EXAMPLE 
	URL for DB Connection example: http://code.google.com/support/bin/answer.py?answer=69906&topic=11367#outputkml	
-->


<html xmlns="http://www.w3.org/1999/xhtml" 
      xmlns:v="urn:schemas-microsoft-com:vml">

 <head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>PHP KML FILE GENERATE</title>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAA1JN_Rfr1vkRSddgFBBL8TBSWxYVcfSMUG_bEjrAWdgFdIhmPKRQTr4SGQ7Y_hRLkfgr45OCsUvRqhA"
      type="text/javascript"></script>


    <script type="text/javascript"> 
   
    var map;
    var geoXml;
    var geoRigXml, geoHole, geoOffice;
    var toggleState = 1;
	
	//New Red Icon
	var icons = new Array();

	icons["normal"] = new GIcon(); 
	icons["normal"].image = "http://maps.google.com/mapfiles/kml/pal3/icon55.png"; 
	icons["normal"].shadow="http://maps.google.com/mapfiles/kml/pal3/icon55s.png"; 
	icons["normal"].iconSize=new GSize(32,32);
	icons["normal"].shadowSize=new GSize(56, 32); 
	icons["normal"].iconAnchor=new GPoint(9,34); 
	icons["normal"].infoWindowAnchor=new GPoint(9,2); 
	icons["normal"].infoShadowAnchor=new GPoint(18,25); 
	icons["normal"].printImage="http://www.google.com/mapfiles/markerie.gif"; 
	icons["normal"].mozPrintImage="http://www.google.com/mapfiles/markerff.gif"; 
	icons["normal"].printShadow="http://www.google.com/mapfiles/dithshadow.gif"; 
	icons["normal"].transparent="http://www.google.com/mapfiles/markerTransparent.png";
	icons["normal"].imageMap=[9,0,6,1,4,2,2,4,0,8,0,12,1,14,2,16,5,19,7,23,8,26,9,30,9,34,11,34,11,30,12,26,13,24,14,21,16,18,18,16,20,12,20,8,18,4,16,2,15,1,13,0];

		
	icons["red"] = new GIcon(); 
	icons["red"].image = "http://maps.google.com/mapfiles/kml/pal3/icon34.png"; 
	icons["red"].shadow="http://maps.google.com/mapfiles/kml/pal3/icon34s.png"; 
	icons["red"].shadowSize=new GSize(37, 34); 
	icons["red"].iconAnchor=new GPoint(9,34); 
	icons["red"].infoWindowAnchor=new GPoint(9,2); 
	icons["red"].infoShadowAnchor=new GPoint(18,25); 
	icons["red"].printImage="http://www.google.com/mapfiles/markerie.gif"; 
	icons["red"].mozPrintImage="http://www.google.com/mapfiles/markerff.gif"; 
	icons["red"].printShadow="http://www.google.com/mapfiles/dithshadow.gif"; 
	icons["red"].transparent="http://www.google.com/mapfiles/markerTransparent.png";
	icons["red"].imageMap=[9,0,6,1,4,2,2,4,0,8,0,12,1,14,2,16,5,19,7,23,8,26,9,30,9,34,11,34,11,30,12,26,13,24,14,21,16,18,18,16,20,12,20,8,18,4,16,2,15,1,13,0];

	icons["missingCountry"] = new GIcon(); 
	icons["missingCountry"].image = "http://maps.google.com/mapfiles/kml/pal4/icon55.png"; 
	icons["missingCountry"].shadow="http://maps.google.com/mapfiles/kml/pal4/icon55s.png"; 
	icons["missingCountry"].iconSize=new GSize(32,32);
	icons["missingCountry"].shadowSize=new GSize(56, 32); 
	icons["missingCountry"].iconAnchor=new GPoint(9,34); 
	icons["missingCountry"].infoWindowAnchor=new GPoint(9,2); 
	icons["missingCountry"].infoShadowAnchor=new GPoint(18,25); 
	icons["missingCountry"].printImage="http://www.google.com/mapfiles/markerie.gif"; 
	icons["missingCountry"].mozPrintImage="http://www.google.com/mapfiles/markerff.gif"; 
	icons["missingCountry"].printShadow="http://www.google.com/mapfiles/dithshadow.gif"; 
	icons["missingCountry"].transparent="http://www.google.com/mapfiles/markerTransparent.png";
	icons["missingCountry"].imageMap=[9,0,6,1,4,2,2,4,0,8,0,12,1,14,2,16,5,19,7,23,8,26,9,30,9,34,11,34,11,30,12,26,13,24,14,21,16,18,18,16,20,12,20,8,18,4,16,2,15,1,13,0];
	
   	function get_icon(iconColor) {
	   	//alert(iconColor);
		if ((typeof(iconColor)=="undefined") || (iconColor==null)) { 
			iconColor = "normal"; 
		}
		if (!icons[iconColor]) {
			icons[iconColor] = new GIcon(icons["normal"]);
			icons[iconColor].image = "mapIcons/marker_"+ iconColor +".png";
		} 
		return icons[iconColor];
	}
      
	function createMarker(point,html,iconStr) {
		
		// FF 1.5 fix
		html = '<div style="white-space:nowrap;">' + html + '</div>';
		var marker = new GMarker(point);
		if (iconStr) {
			marker = new GMarker(point, get_icon(iconStr));
		}

		//var marker = new GMarker(point);
		GEvent.addListener(marker, "click", function() {
			marker.openInfoWindowHtml(html);
		});
		return marker;
	}

    
    
    //This is where we read the newly produced KML file and we load it in the API
	function initialize() {
		
  	  if (GBrowserIsCompatible()) {
  	    
	  	//THIS IS TEMPORARY UNTIL WE GET A DMZ SITE. WE FTP THIS FILE MANUALLY.
		//OLD CODE START
		/*		
  	    geoXml = new GGeoXml("http://www.bulletproofsi.com/wireline/MAJOR_KML147.kml");
	  	map = new GMap2(document.getElementById("map_canvas"));
       // map.setCenter(new GLatLng(33.2951,-111.052), 1); 
        map.addControl(new GLargeMapControl());
        map.addControl(new GMapTypeControl());
        map.setMapType(G_HYBRID_MAP);
        map.enableScrollWheelZoom();
        map.setZoom(2);
        map.addOverlay(geoXml);
		*/        
        //OLD CODE ENDS
        
        //NEW CODE STARTS
        map = new GMap2(document.getElementById("map_canvas"));
        map.setCenter(new GLatLng(33.2951,-111.052), 2);  			//This should be able to change depending on who's logged on -- (SharePoint)
        //the depth or level of the view
        map.addControl(new GLargeMapControl());
        map.addControl(new GMapTypeControl());
        map.setMapType(G_HYBRID_MAP);
        map.enableScrollWheelZoom();
	}
      	
     
      <?php

		//DB CONNECTION CODE
		$connect = odbc_connect("Damiantest", "sa", "password");
		if( $connect == 0 ) {  //Note that the the client machine has to be connected to the CheckPoint VPN in order to access this 10.0.32.87 box.
		    // Error reporting/handling here.
		    echo "ERROR CONNECTING TO DB";
		}
		else{
			//DB CONNECTION SUCCESS
			
			//Begin the KML file array output (Now only used for Google Earth Download)
			$kml = array('<?xml version="1.0" encoding="UTF-8"?>');
			$kml[] = '<kml xmlns="http://earth.google.com/kml/2.2">';
			$kml[] = '<Document>';
			$kml[] = '<name>MAJOR_KML.kml</name>';
			$kml[] = '<Style id="sh_ylw-pushpin">';
			$kml[] = '<IconStyle>';
			$kml[] = '<scale>1.3</scale>';
			$kml[] = '<Icon>';
			$kml[] = '<href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>';
			$kml[] = '</Icon>';
			$kml[] = '<hotSpot x="20" y="2" xunits="pixels" yunits="pixels"/>';
			$kml[] = '</IconStyle>';
			$kml[] = '</Style>';
			$kml[] = '<Style id="sn_ylw-pushpin">';
			$kml[] = '<IconStyle>';
			$kml[] = '<scale>1.1</scale>';
			$kml[] = '<Icon>';
			$kml[] = '<href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>';
			$kml[] = '</Icon>';
			$kml[] = '<hotSpot x="20" y="2" xunits="pixels" yunits="pixels"/>';	
			$kml[] = '</IconStyle>';
			$kml[] = '</Style>';
			$kml[] = '<StyleMap id="msn_ylw-pushpin">';
			$kml[] = '<Pair>';
			$kml[] = '<key>normal</key>';
			$kml[] = '<styleUrl>#sn_ylw-pushpin</styleUrl>';
			$kml[] = '</Pair>';
			$kml[] = '<Pair>';
			$kml[] = '<key>highlight</key>';	
			$kml[] = '<styleUrl>#sh_ylw-pushpin</styleUrl>';
			$kml[] = '</Pair>';
			$kml[] = '</StyleMap>';
				
			//Fetch data from DamianTest DB, wireline_header Table
			$query = "SELECT * FROM wireline_data";
			$result = odbc_exec($connect, $query);
			$holeid = "0";
			$i = 0;

			while(odbc_fetch_row($result)){
				
				$arrayValues[$i][0] = trim(odbc_result($result, 2)); //hole id
				$arrayValues[$i][1] = trim(odbc_result($result, 19)); //speed
				$arrayValues[$i][2] = trim(odbc_result($result, 20)); //force
				$arrayValues[$i][3] = trim(odbc_result($result, 5)); //latitude
				$arrayValues[$i][4] = trim(odbc_result($result, 4)); //longitude
				$arrayValues[$i][5] = trim(odbc_result($result, 3)); //rig id
				$i++;
				
				//We loop thru the records. When we find a different hole id, we add it to the map
				if(trim(odbc_result($result, 2)) != $holeid){
					
					$holeid = trim(odbc_result($result, 2)); 
					$latitude = trim(odbc_result($result, 5)); 
					$longitude = trim(odbc_result($result, 4)); 
					$rigid = trim(odbc_result($result, 3));
					
					$kml[] = '<Placemark>';
					$kml[] = '<name>Drill ' . $rigid . '</name>';
					$kml[] = '<description><![CDATA[<A href="http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=' . $holeid . '&DATE=06/12/2008">Launch Crystal Report</A> ]]></description>';
					$kml[] = '<LookAt>';
					$kml[] = '<longitude>' . $longitude . '</longitude>';
					$kml[] = '<latitude>' . $latitude . '</latitude>';	
					$kml[] = '<altitude>0</altitude>';	
					$kml[] = '<range>398420.8373023096</range>';	
					$kml[] = '<tilt>0</tilt>';	
					$kml[] = '<heading>2.389481646317443e-014</heading>';	
					$kml[] = '</LookAt>';	
					$kml[] = '<styleUrl>#msn_ylw-pushpin</styleUrl>';	
					$kml[] = '<Point>';	
					$kml[] = '<coordinates>' . $longitude . ',' . $latitude . ',0</coordinates>';	
					$kml[] = '</Point>';	
					$kml[] = '</Placemark>';
				}
			}
			$kml[] = '</Document>';
			$kml[] = '</kml>';

			//Get the wireline_monitor data
			$query = "SELECT * FROM wireline_monitor";
			$resultMonitor = odbc_exec($connect, $query);
			$counter = 0;
			while(odbc_fetch_row($resultMonitor)){
				
				$arrayMonitor[$counter][0] = trim(odbc_result($resultMonitor, 1)); //drillid
				$arrayMonitor[$counter][1] = trim(odbc_result($resultMonitor, 2)); //country
				$arrayMonitor[$counter][2] = trim(odbc_result($resultMonitor, 3)); //speed
				$arrayMonitor[$counter][3] = trim(odbc_result($resultMonitor, 4)); //force
				
				$counter++;
			}
			
			for($counter = 0; $counter < sizeof($arrayValues); $counter++){
				
				$speedInterval += $arrayValues[$counter][1];
				$forceInterval += $arrayValues[$counter][2];
			
				if($arrayValues[$counter][0] == $arrayValues[$counter+1][0]){
					;
				}
				else{
					//write the marker based on speed and force average
			        //find out the average speeds and forces from the "wireline_monitor" table
			        for($monitorCounter = 0; $monitorCounter < sizeof($arrayMonitor); $monitorCounter++){
				    	if(strtolower($arrayValues[$counter][5]) == strtolower($arrayMonitor[$monitorCounter][0])){
					    	//if we find a match in drill id, we now look at averaging the speed and force
					    	$averageSpeed = $speedInterval/sizeof($arrayValues[$counter]);
					    	$averageForce = $forceInterval/sizeof($arrayValues[$counter]);
					    	
					    	//echo 'alert(\'drill id = ' . $arrayMonitor[$monitorCounter][0] . '\');';
					    	//echo 'alert(\'Suggested Avg Speed = ' . $arrayMonitor[$monitorCounter][2] . ' Actual Speed Avg = ' . $averageSpeed . '\');';
					    	//echo 'alert(\'Suggested Avg Force = ' . $arrayMonitor[$monitorCounter][3] . ' Actual Force Avg = ' . $averageForce . '\');';
					    	
					    	
					    	if($arrayMonitor[$monitorCounter][2] > $averageSpeed){
						    	$markerIcon = 'red_speed';	
					    	}
					    	else if ($arrayMonitor[$monitorCounter][3] < $averageForce){
						    	$markerIcon = 'red_force';	
					    	}
					    	else if($arrayMonitor[$monitorCounter][2] == '' || $arrayMonitor[$monitorCounter][3] == '' || $arrayMonitor[$monitorCounter][1] == ''){
						    	$markerIcon = 'missingCountry';	
					    	}
					    	else{
						    	$markerIcon = 'normal';	
					    	}
					    	
					    	break;
				    	}
			        }
			        
			        echo "var point = new GLatLng(" . $arrayValues[$counter][3] . "," . $arrayValues[$counter][4] . "); \n";
	   		        
			        if($markerIcon == 'red_speed'){
						echo "var marker = createMarker(point,'<table cellspacing=0>  <tr> <td colspan=\"2\"> <table><tr><td> <FONT COLOR=\"red\"> This drill is performing under</FONT> </td></tr><tr><td> <FONT COLOR=\"red\"> targeted speeds </FONT> </td></tr></table>   </td></tr>    <tr><td><b>" . $arrayValues[$counter][5] . "</b></td><td rowspan=\"2\"><img src=\"./graph.png\"/></td></tr><tr><td><b>" . $arrayValues[$counter][0] . "</b></td></tr><tr><td><A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $arrayValues[$counter][0] . "&DATE=07/09/2008 16:35:42\" target=\"_blank\">View Detailed Report</A></td></tr></table>','red') \n"; 
			        }
			        else if($markerIcon == 'red_force'){
						echo "var marker = createMarker(point,'<table cellspacing=0>  <tr> <td colspan=\"2\"> <table><tr><td> <FONT COLOR=\"red\"> This drill is performing over</FONT> </td></tr><tr><td> <FONT COLOR=\"red\"> targeted forces </FONT> </td></tr></table>   </td></tr>    <tr><td><b>" . $arrayValues[$counter][5] . "</b></td><td rowspan=\"2\"><img src=\"./graph.png\"/></td></tr><tr><td><b>" . $arrayValues[$counter][0] . "</b></td></tr><tr><td><A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $arrayValues[$counter][0] . "&DATE=07/09/2008 16:35:42\" target=\"_blank\">View Detailed Report</A></td></tr></table>','red') \n"; 
			        }
			        else if($markerIcon == 'missingCountry'){
				    	echo "var marker = createMarker(point,'<table cellspacing=0>  <tr> <td colspan=\"2\"> <table><tr><td> <FONT COLOR=\"red\"> This drill is missing monitoring information.</FONT> </td></tr><tr><td> <FONT COLOR=\"red\"> Please click on this </FONT> <a href=\"http://10.0.32.87/major/index.php\" target=\"_blank\">link</a> <FONT COLOR=\"red\"> to resolve </FONT> </td></tr></table>   </td></tr>    <tr><td><b>" . $arrayValues[$counter][5] . "</b></td><td rowspan=\"2\"><img src=\"./graph.png\"/></td></tr><tr><td><b>" . $arrayValues[$counter][0] . "</b></td></tr><tr><td><A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $arrayValues[$counter][0] . "&DATE=07/09/2008 16:35:42\" target=\"_blank\">View Detailed Report</A></td></tr></table>','" . $markerIcon . "') \n"; 
			        }
			        else{
				        echo "var marker = createMarker(point,'<table cellspacing=0><tr><td><b>" . $arrayValues[$counter][5] . "</b></td><td rowspan=\"2\"><img src=\"./graph.png\"/></td></tr><tr><td><b>" . $arrayValues[$counter][0] . "</b></td></tr><tr><td><A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $arrayValues[$counter][0] . "&DATE=07/09/2008 16:35:42\" target=\"_blank\">View Detailed Report</A></td></tr></table>','" . $markerIcon . "') \n"; 
			        }
			        //echo "var marker = createMarker(point,'<table cellspacing=0><tr><td><b>" . $arrayValues[$counter][5] . "</b></td><td rowspan=\"2\"><img src=\"./graph.png\"/></td></tr><tr><td><b>" . $arrayValues[$counter][0] . "</b></td></tr><td><A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $arrayValues[$counter][0] . "&DATE=07/09/2008 16:35:42\">View Detailed Report</A></td></tr></table>','" . $markerIcon . "') \n"; 
			        echo "map.addOverlay(marker); \n";
			        
			        
			        
			        //reset the intervals
			        $speedInterval = 0;
			        $forceInterval = 0;
					
				}
				
				//Javascript Code for Map Marker Creation
		        //echo "var point = new GLatLng(" . $latitude . "," . $longitude . "); \n";
		        //echo "var marker = createMarker(point,'<A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $holeid . "&DATE=07/09/2008 16:35:42\">Launch " . $holeid . " Crystal Report</A>','normal') \n"; 
		        
		        //logic here to determine whether or not a marker is "normal", "red" or "missingCountry"
		        //echo 'alert(\'rig id = ' . $rigid . '\');';
		        //echo 'alert(\'SPEED = ' . $speedInterval . '\');';
		        //echo 'alert(\'FORCE = ' . $forceInterval . '\');';
		        
		        //echo "var marker = createMarker(point,'<table cellspacing=0><tr><td><b>" . $rigid . "</b></td><td rowspan=\"2\"><img src=\"./graph.png\"/></td></tr><tr><td><b>" . $holeid . "</b></td></tr><td><A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $holeid . "&DATE=07/09/2008 16:35:42\">View Detailed Report</A></td></tr></table>','normal') \n"; 
		        //echo "map.addOverlay(marker); \n";
		        
			}
			
		//TEMPORARY FOR RED ICON MARKER
		/*		
        echo "var point = new GLatLng(40.11,100.48); \n";
        echo "var marker = createMarker(point,'<table cellspacing=0><tr><td><b>" . $rigid . "</b></td><td rowspan=\"2\"><img src=\"./graph.png\"/></td></tr><tr><td><b>" . $holeid . "</b></td></tr><td><A href=\"http://10.0.32.87/WebSetup1/Default.aspx?HOLEID=" . $holeid . "&DATE=07/09/2008 16:35:42\">View Detailed Report</A></td></tr></table>','red') \n"; 
        echo "map.addOverlay(marker); \n";
		*/	
			
		

	//Close the open DB Connection
	odbc_close($connect);
}
?>	 
     } 

    </script>
  </head>

<?
	$fp = fopen("./MAJOR_KML.kml","wb"); 
	
	for($z = 0; $z < sizeof($kml); $z++){
		fwrite($fp, $kml[$z]); 
	}
	fclose($fp);
?>

  <body onload="initialize()">
  <img src="http://www.bulletproofsi.com/wireline/transparent.bmp" /> 
  <a href="http://10.0.32.87/download_kml.php" >
		<span>View in Google Earth</span>
  </a>
  
      <div id="map_canvas" style="width: 1000px; height: 750px; float:left; border: 1px solid black;"></div>
    </div>
    <br clear="all"/>
    <br/>
  </body>
</html>
