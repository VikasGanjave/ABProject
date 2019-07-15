using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorBook.Models.ViewModel
{
    public class BookVM
    {
        private AuthorsBooksEntities db = new AuthorsBooksEntities();

        public int BookID { get; set; }
        public string Title { get; set; }
        public string Active { get; set; }
        public string SoftDelete { get; set; }

        List<BookVM> BookVMList { get; set; }

        public BookVM()
        {

        }

        public BookVM(Book BookObj,AuthorsBooksEntities db)
        {
            this.db = db;
            this.BookID = BookObj.BookID;
            this.Title = BookObj.Title;
            this.Active = BookObj.Active;
            this.SoftDelete = BookObj.SoftDelete;
        }


        public List<BookVM> GetBookList(int ID, AuthorsBooksEntities db)
        {
            List<BookVM> BookVMList = new List<BookVM>();
            var book = db.Books.Where(p => p.BookID == ID).ToList();
            foreach (var bookobj in book)
            {
                BookVM VMObj = new BookVM(bookobj, db);
                var Book = db.Books.Where(p => p.BookID == bookobj.BookID).FirstOrDefault();
                BookVMList.Add(VMObj);
            }
            return BookVMList;
        }

        public List<BookVM> GetAllBook(AuthorsBooksEntities db)
        {
            List<BookVM> BookVMlist = new List<BookVM>();
            //var AuthorList = db.Authors.Where(p => p.Active.Equals("Y")).ToList();
            var BookList = db.Books.Where(p => p.Active.Equals("Y")).ToList();

            foreach (var bookObj in BookList)
            {
                BookVM VMObj = new BookVM(bookObj, db);
                var BookObj = db.Books.Where(p => p.BookID == bookObj.BookID).ToList();

                BookVMlist.Add(VMObj);
            }

            return BookVMlist;

        }

    }
}