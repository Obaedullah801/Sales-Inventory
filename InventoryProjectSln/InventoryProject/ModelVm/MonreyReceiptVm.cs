using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryProject.ModelVm
{
    public class MonreyReceiptVm
    {
        public int MR_ID { get; set; }
        public int PartyCode { get; set; }
        public int Tr_MasterID { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Amount { get; set; }
    }
}