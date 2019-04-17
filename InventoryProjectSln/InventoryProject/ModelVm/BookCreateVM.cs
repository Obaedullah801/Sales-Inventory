using InventoryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryProject.ModelVM
{
    public class BookCreateVM
    {
        
        public int BookID { get; set; }
        public Nullable<int> BookGroupID { get; set; }
        public string BookName { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Commission { get; set; }
        public Nullable<int> BookOpnBalance { get; set; }
        public string AuthorName { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> ReturnRate { get; set; }
        public Nullable<int> BookForma { get; set; }
    
        public virtual BookGroup BookGroup { get; set; }
        public virtual ICollection<Tr_Details> Tr_Details { get; set; }


        public IEnumerable<SelectListItem> selectListOrganization { get; set; }
        public IEnumerable<SelectListItem> selectListBook { get; set; }

        public bool IsDeleted { get; set; }
    }
}