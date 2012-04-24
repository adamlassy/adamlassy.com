using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void Page_Init(object sender, EventArgs e)
    {
        ConfigureCrystalReports();
    }

    private void ConfigureCrystalReports()
    {
        ReportDocument rpt = new ReportDocument();
        String reportPath = "C:\\wireline_repository\\wireline_MD1_summary.rpt";

        rpt.Load(reportPath);
        crystalReportViewer.ReportSource = rpt;

        if (!(Logon(rpt, "Damiantest", "DamianTest", "sa", "password"))){
            //print "COULD NOT LOG ON TO DB SERVER";
            ;
        }

        //MPoirier: Date Format to call rpt: MM/DD/YYYY, Examples: 
        //http://localhost:3092/CrystalReportViewer/Default.aspx?HOLEID=1&DATE=06/12/2006
        //http://localhost:3092/CrystalReportViewer/Default.aspx?HOLEID=1&DATE=06%2f12%2f2006
        //http://localhost/WebSetup1/Default.aspx?HOLEID=1&DATE=06%2f12%2f2006 (locally from server box)

        int cnt = rpt.DataDefinition.ParameterFields.Count;
        for (int i = 0; i < cnt; i++)
        {
            ParameterValues myvals = new ParameterValues();
            ParameterDiscreteValue myDiscrete = new ParameterDiscreteValue();

            switch (rpt.DataDefinition.ParameterFields[i].ParameterValueKind)
            {
                case CrystalDecisions.Shared.ParameterValueKind.DateTimeParameter:
                    myDiscrete.Value = Convert.ToDateTime(Request.QueryString[i]);
                    break;
                case CrystalDecisions.Shared.ParameterValueKind.BooleanParameter:
                    myDiscrete.Value = bool.Parse(Request.QueryString[i]);
                    break;
                case CrystalDecisions.Shared.ParameterValueKind.DateParameter:
                    myDiscrete.Value = Convert.ToDateTime(Request.QueryString[i]);
                    break;
                case CrystalDecisions.Shared.ParameterValueKind.NumberParameter:
                    myDiscrete.Value = int.Parse(Request.QueryString[i]);
                    break;
                case CrystalDecisions.Shared.ParameterValueKind.StringParameter:
                    myDiscrete.Value = Convert.ToString((Request.QueryString[i]));
                    break;
            }
            myvals.Add(myDiscrete);
            rpt.DataDefinition.ParameterFields[i].ApplyCurrentValues(myvals);
        }
        
        crystalReportViewer.ReportSource = rpt;
        //crystalReportViewer.DataBind();
    }

    bool ApplyLogon(ReportDocument cr, ConnectionInfo ci){

        TableLogOnInfo li;

        // for each table apply connection info
        foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in cr.Database.Tables){

            li = tbl.LogOnInfo;
            li.ConnectionInfo = ci;
            tbl.ApplyLogOnInfo(li);

            // check if logon was successful
            // if TestConnectivity returns false, check
            // logon credentials

            if (tbl.TestConnectivity()){

                // drop fully qualified table location
                if (tbl.Location.IndexOf(".") > 0){
                    tbl.Location = tbl.Location.Substring(tbl.Location.LastIndexOf(".") + 1);
                }

                else {
                    tbl.Location = tbl.Location;
                }
            }

            else{ 
                return(false);
            }
        }

        return(true);
    }

    bool Logon(ReportDocument cr, string server, string db, string id, string pass){

        ConnectionInfo ci = new ConnectionInfo();
        SubreportObject subObj;

        ci.ServerName = server;
        ci.DatabaseName = db;
        ci.UserID = id;
        ci.Password = pass;

        if (!ApplyLogon(cr, ci)) return (false);

        foreach (ReportObject obj in cr.ReportDefinition.ReportObjects){
            if (obj.Kind == ReportObjectKind.SubreportObject){
                subObj = (SubreportObject)obj;
                if (!ApplyLogon(cr.OpenSubreport(subObj.SubreportName), ci)) 
                    return (false);
            }
        }
        return (true);
    }
}
