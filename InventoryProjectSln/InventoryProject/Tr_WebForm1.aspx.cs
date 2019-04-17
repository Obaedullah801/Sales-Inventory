using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryProject.Models;
using Microsoft.Reporting.WebForms;

namespace InventoryProject
{
    public partial class Tr_WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateReport();
            }
            
        }
        private void PopulateReport()
        {
            using (Tr_DBEntities db = new Tr_DBEntities())
            {
                var v = (from a in db.GetDetailProc()
                         select a);
                ReportDataSource rd = new ReportDataSource("ds_Tr", v.ToList());
                ReportViewer1.LocalReport.DataSources.Add(rd);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}