using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;
using Microsoft.Office.Workflow.Utility;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace wirelineparser_master
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {

            string ReturnMessage = "";
            string line = "";
            string hole_id = " ";
            string finalrecord;
            string wireline_direction = "";
            int wireline_rate;
            int sr_dep = 0;
            int run_no = 1;
            int arraySize = 0;
           
                //There is a workflow Item to process so open the database connection
                SqlConnection dbConn = new SqlConnection("Data Source=10.0.4.14/MDGBKP01;initial catalog=WIRELINE;User ID=wireline_user;Password=w1reline;");
                dbConn.Open();
                //open the input file
                StreamReader sr = new StreamReader(workflowProperties.Item.File.OpenBinaryStream());

                //read the input file line by line
                while((line = sr.ReadLine()) != null)
                {

                    //Catch the last return statement at the end of the file is it's present. If this is not caught, the application returns an exception.
                    if (line == "")
                    {
                        break;
                    }

                    String[] arrayString = line.Split(',');

                    if (arrayString[1] == hole_id)
                    {
                        run_no = run_no + 1;
                    }
                    else
                    {
                        hole_id = arrayString[1];
                        run_no = 1;
                    }

                    arraySize = arrayString.Length;

                    //First 21 items, should be part of the 1st set, all the way to the date field. 
                    string firstSet =
                        arrayString[0] + ","					//Job Number				(MD1)
                        + arrayString[1] + ","					//Hole ID					(MD1)
                        + arrayString[2] + ","					//Rig ID					(MD1)
                        + arrayString[3] + ","	                //GPS Longitude				(MD1)
                        + arrayString[4] + ","	                //GPS Latitude				(MD1)
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

                    string thirdSet = arrayString[arraySize - 4] + "," + arrayString[arraySize - 3] + "," + arrayString[arraySize - 2] + "," + arrayString[arraySize - 1];
                    wireline_rate = int.Parse(arrayString[5]);
		            wireline_direction = arrayString[19];
		            string wireline_measurement_unit = arrayString[18];

		            //Check to make sure there is actually at least 1 speed and 1 force in the record. If there is not, default them to zero.
		            string compareString = arrayString[22] + "," + arrayString[23] + "," + arrayString[24] + "," + arrayString[25];

		        if(thirdSet.CompareTo(compareString) == 0){ //zero means equal
			
			        //write the record with speed and force equal to zero but leave depth as is.
			        finalrecord = firstSet + ",0,0," + thirdSet + "," + run_no.ToString() + "," + sr_dep.ToString();
		      
                }
		        else{
			        for(int b = 22; b < arraySize - 4; b = b + 2){
				
				    //Loop thru these and add a row in the new txt file for every speed (including the 1st and 3rd blocks)
				    //Also add run_no and sr_dep(wireline_rate calc) in the last 2 slots of the output row
				
				    if(b != 22) {
						//if it's wireline down, add. If it's wireline up, remove.				
					    if(wireline_direction.CompareTo("WD") == 0 | wireline_direction.CompareTo("wd") == 0)
					    {
						    //sr_dep = wireline_rate * counter;
						    sr_dep += wireline_rate;
					    }
					    else //WU
					    {
						    sr_dep -= wireline_rate;
					    }
				}
				//once the record has been reassembled in the proper format, re-parse the message
				finalrecord = firstSet + "," + arrayString[b] + "," + arrayString[b + 1] + "," + thirdSet + "," + run_no.ToString() + "," + sr_dep.ToString();
				String[] arrayStringFinal = finalrecord.Split(',');
                int param_count = arrayStringFinal.Length;
                
                SqlCommand InsertCMD = new SqlCommand("wireline_load", dbConn);
                SqlCommand postProc  = new SqlCommand("post_load_processing", dbConn);

                InsertCMD.CommandType = CommandType.StoredProcedure;
                postProc.CommandType  = CommandType.StoredProcedure;
                      
                //assign all parameter values
                SqlParameter param;
                param = InsertCMD.Parameters.Add("@job",SqlDbType.Char);
                param.Value = arrayStringFinal[0];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@hole", SqlDbType.Char);
                param.Value = arrayStringFinal[1];
                param.Direction = ParameterDirection.Input;                
                param = InsertCMD.Parameters.Add("@rig", SqlDbType.Char);
                param.Value = arrayStringFinal[2];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@long", SqlDbType.Char);
                param.Value = arrayStringFinal[3];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@lat", SqlDbType.Char);
                param.Value = arrayStringFinal[4];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@wl_rate", SqlDbType.Char);
                param.Value = arrayStringFinal[5];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@drl_rate", SqlDbType.Char);
                param.Value = arrayStringFinal[6];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@hl_size", SqlDbType.Char);
                param.Value = arrayStringFinal[7];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@hl_inc", SqlDbType.Char);
                param.Value = arrayStringFinal[8];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@drl_rods", SqlDbType.VarChar);
                param.Value = arrayStringFinal[9];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@tube_head", SqlDbType.VarChar);
                param.Value = arrayStringFinal[10];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@c_brl_len", SqlDbType.VarChar);
                param.Value = arrayStringFinal[11];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@os_size", SqlDbType.Char);
                param.Value = arrayStringFinal[12];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@core_or", SqlDbType.Char);
                param.Value = arrayStringFinal[13];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@core_or_by", SqlDbType.Char);
                param.Value = arrayStringFinal[14];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@water_dep", SqlDbType.Char);
                param.Value = arrayStringFinal[15];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@md1_ver", SqlDbType.Char);
                param.Value = arrayStringFinal[16];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@rd3_ser", SqlDbType.Char);
                param.Value = arrayStringFinal[17];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@me", SqlDbType.Char);
                param.Value = arrayStringFinal[18];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@w_ud", SqlDbType.Char);
                param.Value = arrayStringFinal[19];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@start", SqlDbType.VarChar);
                param.Value = arrayStringFinal[20];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@date", SqlDbType.VarChar);
                param.Value = arrayStringFinal[21];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@force", SqlDbType.Char);
                param.Value = arrayStringFinal[22];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@speed", SqlDbType.Char);
                param.Value = arrayStringFinal[23];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@pk_frc", SqlDbType.Char);
                param.Value = arrayStringFinal[24];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@pk_dep", SqlDbType.Char);
                param.Value = arrayStringFinal[25];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@dist", SqlDbType.Char);
                param.Value = arrayStringFinal[26];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@end", SqlDbType.VarChar);
                param.Value = arrayStringFinal[27];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@run", SqlDbType.Char);
                param.Value = arrayStringFinal[28];
                param.Direction = ParameterDirection.Input;
                param = InsertCMD.Parameters.Add("@sr_dep", SqlDbType.Char);
                param.Value = arrayStringFinal[29];
                param.Direction = ParameterDirection.Input;
              
                 
                //assign a parameter for a return value
                SqlParameter RetVal = InsertCMD.Parameters.Add("RetVal", SqlDbType.Int);
                RetVal.Direction = ParameterDirection.ReturnValue;
                //once all of the paramaters have been collected execute the store procedure
                try
                {
                  int x = InsertCMD.ExecuteNonQuery();
                  int p = postProc.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ReturnMessage = String.Format("{0} {1} /n/r", ReturnMessage, ex.ToString());
                }
                if (RetVal.Value.Equals(0))
                {
                    ReturnMessage = String.Format("{0} {1} /n/r", ReturnMessage, "An Error has occurred");
                }
                    
                }
		}		
	}
   
  


        }
    }
}
