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
    public class AuthorAPIController : ApiController
    {
        AuthorsBooksEntities db = new AuthorsBooksEntities();
        AuthorVM AuthorVMObj = new AuthorVM();

        [System.Web.Http.HttpGet]
        public List<AuthorVM> getAuthorList(int AuthorID)
        {
            List<AuthorVM> AuthorVMList = AuthorVMObj.GetAuthorList(AuthorID,db);
            return AuthorVMList;
        }

        [System.Web.Http.HttpGet]
        public List<AuthorVM> getAllAuthor()
        {
            List<AuthorVM> AuthorVMList = AuthorVMObj.GetAllAuthor(db);
            return AuthorVMList;
        }

        [System.Web.Http.HttpDelete]
        public void deleteAuthor(int ID)
        {
            AuthorVMObj.DeleteAuthor(ID, db);
            
        }



        [System.Web.Http.HttpPost]
        public IHttpActionResult PostNewAuthor(Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var db = new AuthorsBooksEntities())
            {
               
                db.Authors.Add(new Author()
                {

                    AuthorID = author.AuthorID,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    DOB = author.DOB,
                    Active = "Y",
                    SoftDelete = "N"
                });

                db.SaveChanges();
            }

            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult PutAuthor(AuthorVM authorvmobj)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var db = new AuthorsBooksEntities())
            {
                var AuthorObj = db.Authors.Where(s => s.AuthorID == authorvmobj.AuthorID).FirstOrDefault<Author>();

                if (AuthorObj != null)
                {
                    AuthorObj.FirstName = authorvmobj.FirstName;
                    AuthorObj.LastName = authorvmobj.LastName;
                    AuthorObj.DOB = authorvmobj.DOB;

                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

    }
}
