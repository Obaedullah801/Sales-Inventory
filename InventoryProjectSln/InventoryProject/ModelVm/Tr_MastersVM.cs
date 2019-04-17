using InventoryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryProject.ModelVM
{
    public class Tr_MastersVM
    {
       
        public System.Guid Tr_MasterID { get; set; }
        public Nullable<System.DateTime> Tr_Date { get; set; }
        public string MemoNo { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> PackDebit { get; set; }
        public Nullable<int> Less { get; set; }
        public string Type { get; set; }
        public string ReturnLessMemoNo { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> BindID { get; set; }
        public string OrderID { get; set; }
        public Nullable<int> Commission { get; set; }


        public System.Guid Tr_DetailID { get; set; }
        
        public Nullable<int> BookGroupID { get; set; }
        public Nullable<int> BookID { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> Rate { get; set; }
        

        public virtual BookGroup BookGroup { get; set; }
        public virtual Book Book { get; set; }
        public virtual Tr_Masters Tr_Masters { get; set; }


    
        public virtual Client Client { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Tr_Details> Tr_Details { get; set; }
    }
}