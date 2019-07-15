using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthorBook.Models;
using AuthorBook.Models.ViewModel;

namespace AuthorBook.Controllers
{
    public class BookAPIController : ApiController
    {
        AuthorsBooksEntities db = new AuthorsBooksEntities();
        BookVM BookVMObj = new BookVM();

        [System.Web.Http.HttpGet]
        public List<BookVM> getBookList(int ID)
        {
            List<BookVM> BookVMList = BookVMObj.GetBookList(ID, db);
            return BookVMList;
        }

        [System.Web.Http.HttpGet]
        public List<BookVM> getAllBook()
        {
            List<BookVM> BookVMList = BookVMObj.GetAllBook(db);
            return BookVMList;
        }
    }
}
