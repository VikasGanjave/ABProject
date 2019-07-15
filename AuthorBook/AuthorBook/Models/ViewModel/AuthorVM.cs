using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorBook.Models;
using AuthorBook.Models.ViewModel;

namespace AuthorBook.Models.ViewModel
{
    public class AuthorVM
    {
        private AuthorsBooksEntities db = new AuthorsBooksEntities();
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Active { get; set; }
        public string SoftDelete { get; set; }
        List<AuthorVM> AuthorVMList { get; set; }

        public AuthorVM()
        {

        }

        public AuthorVM(Author authorObj, AuthorsBooksEntities db)
        {
            this.db = db;
            this.AuthorID = authorObj.AuthorID;
            this.FirstName = authorObj.FirstName;
            this.LastName = authorObj.LastName;
            this.DOB = authorObj.DOB;
            this.Active = authorObj.Active;
            this.SoftDelete = authorObj.SoftDelete;
        }

        public List<AuthorVM> GetAuthorList(int AuthorID,AuthorsBooksEntities db)
        {
            List<AuthorVM> AuthorVMList = new List<AuthorVM>();
            var author = db.Authors.Where(p => p.AuthorID == AuthorID).ToList();
            foreach (var authorobj in author)
            {
                AuthorVM VMObj = new AuthorVM(authorobj,db);
                var Author = db.Authors.Where(p => p.AuthorID == authorobj.AuthorID).FirstOrDefault();
                AuthorVMList.Add(VMObj);
            }
            return AuthorVMList;
        }

        public List<AuthorVM> GetAllAuthor(AuthorsBooksEntities db)
        {
            List<AuthorVM> AuthorVMlist = new List<AuthorVM>();
            //var AuthorList = db.Authors.Where(p => p.Active.Equals("Y")).ToList();
            var AuthorList = db.Authors.Where(p => p.Active.Equals("Y")).ToList();

            foreach (var authorObj in AuthorList)
            {
                AuthorVM VMObj = new AuthorVM(authorObj, db);
                var AuthorObj = db.Authors.Where(p => p.AuthorID == authorObj.AuthorID).ToList();
                // VMObj.FirstName = AuthorObj.ToString();
                // VMObj.LastName = AuthorObj.ToString();

                AuthorVMlist.Add(VMObj);
            }

            return AuthorVMlist;

        }

        public void DeleteAuthor(int ID, AuthorsBooksEntities db)
        {
            AuthorVM VMObj = new AuthorVM();
            var Author = db.Authors.Find(ID);
            VMObj.FirstName = Author.FirstName;
            VMObj.LastName = Author.LastName;
            VMObj.DOB = Author.DOB;
            Author.SoftDelete = "Y";
            Author.Active = "N";
            db.SaveChanges();

        }

    }
}