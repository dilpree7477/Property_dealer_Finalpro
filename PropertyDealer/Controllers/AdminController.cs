using PropertyDealer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyDealer.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult checkLogin(Admin login)
        {
            //Pass the data to store the record into the table 

            DataTable tbl = new DataTable();
            DatabaseConnection db = new DatabaseConnection();
            tbl =db.Login("select * from LoginDetails where UserName='" + login.lName + "'and UserPassword='" + login.lPassword + "'");

            if (tbl.Rows.Count > 0)
            {
                return View("Right");
            }
            else
            {
                return View("Wrong");
            }



        }





        public ActionResult Right()
        {
            return View();
        }

        public ActionResult Wrong()
        {
            return View();
        }

    }
}