using InventoryProject.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryProject
{
    public partial class ReportWebForm : System.Web.UI.Page
    {
        public Tr_DBEntities db = new Tr_DBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var rs = db.Tr_Masters.OrderByDescending(a=>a.Tr_MasterID).Select(a=>a.Tr_MasterID).First();
                GetReport(Convert.ToInt32(rs));
            }
            
            //if (!IsPostBack)
            //{
            //    GetReport();
            //}
        }
        private void GetReport(int id)
        {

            var v = (from a in db.sp_Tr_MasterDetail()
                     select a);
            ReportDataSource rds = new ReportDataSource("DataSet1", v.OrderByDescending(a => a.Tr_MasterID).Where(a => a.Tr_MasterID == id).ToList());
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
            //using (Tr_DBEntities db = new Tr_DBEntities())
            //{
            //    var v = (from a in db.sp_Tr_MasterDetail()
            //             select a);
            //    ReportDataSource ds = new ReportDataSource("DataSet1", v.ToList());
            //    ReportViewer1.LocalReport.DataSources.Add(ds);
            //    ReportViewer1.LocalReport.Refresh();
            //}
            
        }

    }
}