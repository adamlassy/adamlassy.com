#include "stdafx.h"

typedef vector<string> int_vec_t;

//Function Prototypes
int_vec_t StringSplit(string, string, int_vec_t); 
string convertDegree(string); 
string convertInttoString(int);
int convertStringtoInt(string);

int main(int argc, char* argv[]){

	//Open Wireline File (arg 0)
	string fileName( argv[1] );
	ifstream file_op_IN (argv[1], ios::in | ios::binary);
	fstream file_op_OUT(argv[2], ios::out);
	stringstream ss0;
	int wireline_rate;
	int sr_dep = 0;
	int run_no = 1;
	string hole_id = " ";
	string record;
	string wireline_direction = "";
	bool directionChanged = false;

	while (!file_op_IN.eof()){
		getline (file_op_IN, record);
		
		//Replace the '13' in the string if it's present
		if(record.find(int(13)) < 100000){
			record.erase(record.find(int(13)), (record.find(int(13)))+1);
		}
		
		//Catch the last return statement at the end of the file is it's present. If this is not caught, the application returns an exception.
		if(record == ""){ 
			return 0;
		}

		//Start record manipulation here
		int_vec_t arrayString;
		arrayString = StringSplit(record, ",", arrayString);
		
		if(arrayString[1] == hole_id){
			//Run number changes
			run_no++;
		}
		else{
			hole_id = arrayString[1];
			run_no = 1;
		}
		
		//FORMAT: We will have 1 row for every speed/force combo. Duplication of a lot of data is required to do this.
		
		int sizeOfArray = arrayString.size();
		
		//First 21 items, should be part of the 1st set, all the way to the date field. 
		string firstSet = 
			arrayString[0] + ","					//Job Number				(MD1)
			+ arrayString[1] + ","					//Hole ID					(MD1)
			+ arrayString[2] + ","					//Rig ID					(MD1)
			+ arrayString[3] + ","	                //GPS Longitude				(MD1)
			+ arrayString[4] + ","	                 //GPS Latitude				(MD1)
			+ arrayString[5] + ","					//Wireline Rate				(MD1)
			+ arrayString[6] + ","					//Drilling Rate				(MD1)
			+ arrayString[7] + ","					//Hole Size					(MD1)
			+ arrayString[8] + ","					//Hole Inclination			(MD1)
			+ arrayString[9] + ","					//Drill Rods				(MD1)
			+ arrayString[10] + ","					//Tube Heads				(MD1)
			+ arrayString[11] + ","					//Core Barrel Length		(MD1)
			+ arrayString[12] + ","					//Over Shot Size			(MD1)
			+ arrayString[13] + ","					//Core Orientation			(MD1)
			+ arrayString[14] + ","					//Core Orientation Bypass	(MD1)
			+ arrayString[15] + ","					//Depth Water Table			(MD1)
			+ arrayString[16] + ","					//MD1 Software Version		(Ditco)
			+ arrayString[17] + ","					//MD1 and RD3 Serial Number (Ditco)
			+ arrayString[18] + ","					//Metric or Imperial(M or E)(Ditco)
			+ arrayString[19] + ","					//Wireline Up/Down			(Ditco)
			+ arrayString[20] + ","					//Start Time				(Ditco)
			+ arrayString[21];						//Start Date				(Ditco)

		string thirdSet = arrayString[sizeOfArray - 4] + "," + arrayString[sizeOfArray - 3] + "," + arrayString[sizeOfArray - 2] + "," + arrayString[sizeOfArray - 1];
		
		int counter = 0;
		
		/*
		if(wireline_direction.compare(arrayString[19]) == 0) //0 means equal
			directionChanged = false;
		else
			directionChanged = true;
		*/
		
		
		wireline_rate = convertStringtoInt(arrayString[5]);
		wireline_direction = arrayString[19];
		string wireline_measurement_unit = arrayString[18];

		//Check to make sure there is actually at least 1 speed and 1 force in the record. If there is not, default them to zero.
		string compareString = arrayString[22] + "," + arrayString[23] + "," + arrayString[24] + "," + arrayString[25];

		if(thirdSet.compare(compareString) == 0){ //zero means equal
			
			cout << "missing speed and force. compareString = " << compareString << "\n";
			cout << "missing speed and force. thirdSet = " << thirdSet << "\n\n";
			
			//write the record with speed and force equal to zero but leave depth as is.
			file_op_OUT << firstSet + ",0,0," + thirdSet + "," + convertInttoString(run_no) + "," + convertInttoString(sr_dep) << endl;
		}
		else{
			for(int b = 22; b < sizeOfArray - 4; b = b + 2){
				
				//Loop thru these and add a row in the new txt file for every speed (including the 1st and 3rd blocks)
				//Also add run_no and sr_dep(wireline_rate calc) in the last 2 slots of the output row
				
				if(b == 22) // && directionChanged)
				//if(directionChanged)
					;
				else{
				//If the wireline direction changed and we're NOT writing out the first speed/force, we want to add or remove from depth
				//if(b > 21 || !directionChanged){

					//if it's wireline down, add. If it's wireline up, remove.				
					if(wireline_direction.compare("WD") == 0 || wireline_direction.compare("wd") == 0)
					{
						//sr_dep = wireline_rate * counter;
						sr_dep += wireline_rate;
					}
					else //WU
					{
						sr_dep -= wireline_rate;
					}
				}
				
				file_op_OUT << firstSet + "," + arrayString[b] + "," + arrayString[b + 1] + "," + thirdSet + "," + convertInttoString(run_no) + "," + convertInttoString(sr_dep)
					<< endl;
			}
		}		
	}
	
    file_op_IN.close();
	file_op_OUT.close();
	return 0;
}

int_vec_t StringSplit(string str, string delim, int_vec_t results){
	
	int cutAt;
	
	while( (cutAt = str.find_first_of(delim)) != str.npos ){
		if(cutAt > 0){
			results.push_back(str.substr(0,cutAt));
		}
		str = str.substr(cutAt+1);
	}
	if(str.length() > 0){
		results.push_back(str);
	}

	return results;
}


//Converting Between Decimal Degrees, Degrees, Minutes and Seconds, and Radians
//Example: 30 degrees 15 minutes 22 seconds = 30 + 15/60 + 22/3600 = 30.2561

//Example2: 103:29:22:W, 45:55:33:N = 
//103 + (29 / 60) + (22 / 3600) = 103 + 0.483 + 0.006 = -103.489 (because it's West, there's a negative)
//45 + (55 / 60) + (33 / 3600) = 45 + 0.92 + 0.0092 = 45.9292 (because it's North, there's no negative)
string convertDegree(string strCoordinate){
	double returnDecimalCoordinate;
	string strReturnDecimalCoordinate;
	stringstream ss0;
	stringstream ss1;
	stringstream ss2;
	stringstream ss3;

	double dblValue0 = 0.00;
	double dblValue1 = 0.00;
	double dblValue2 = 0.00;

	int_vec_t arrayStringCoordinates;
	arrayStringCoordinates = StringSplit(strCoordinate, ":", arrayStringCoordinates);

	string strValue0 = arrayStringCoordinates[0];
	string strValue1 = arrayStringCoordinates[1];
	string strValue2 = arrayStringCoordinates[2];

	ss0 << strValue0;
	ss0 >> dblValue0;

	ss1 << strValue1;
	ss1 >> dblValue1;

	ss2 << strValue2;
	ss2 >> dblValue2;

	returnDecimalCoordinate = dblValue0 + (dblValue1/60.0) + (dblValue2/3060.0);
	
	ss3 << returnDecimalCoordinate;
	ss3 >> strReturnDecimalCoordinate;
  
	if(	arrayStringCoordinates[3] == "S"	|| arrayStringCoordinates[3] == "s" ||
		arrayStringCoordinates[3] == "W"	|| arrayStringCoordinates[3] == "w"){
			return "-" + strReturnDecimalCoordinate;
	}
	else{
		return strReturnDecimalCoordinate;
	}
}

string convertInttoString(int var){
	
	stringstream ss0;
	string returnValue;

	ss0 << var;
	ss0 >> returnValue;
	
	return returnValue;
}

int convertStringtoInt(string var){
	
	stringstream ss0;
	int returnValue;

	ss0 << var;
	ss0 >> returnValue;
	
	return returnValue;
}