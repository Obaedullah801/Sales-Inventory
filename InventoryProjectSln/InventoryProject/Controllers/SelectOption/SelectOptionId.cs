using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryProject.Models;
using InventoryProject.ModelVM;

namespace InventoryProject.Controllers.SelectOption
{
    public class SelectOptionId
    {
        Tr_DBEntities db = new Tr_DBEntities();
        public IEnumerable<SelectListItem> SelectBook()
        {

            List<Book> books = new List<Book>();


            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Book bookData in books)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = bookData.BookName;
                selectListItem.Value = bookData.BookID.ToString();

                selectListItems.Add(selectListItem);
            }

            return selectListItems;

        }
        //public List<Book> GetAllCourses()
        //{
        //    return GetAllCourse();
        //}
        //public List<Book> GetAllCourse()
        //{
        //    List<Book> courses = db.Books
        //                          .Where(c => c.IsDeleted == false)
        //                          .OrderByDescending(c => c.BookID)
        //                          .ToList();
        //    return courses;
        //}
    }
}