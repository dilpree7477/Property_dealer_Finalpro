using PropertyDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyDealer.Controllers
{
    public class HomeController : Controller
    {
        PropertyDealerEntities PropertyDealer = new PropertyDealerEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult sendQuery(Contact contact)
        {
            //Pass the data to store the record into the table 

            DatabaseConnection db = new DatabaseConnection();
            db.sendMessage("insert into ContactDetails values('" + contact.lName + "','" + contact.lSender + "','" + contact.lMessage + "')");
            return View("done");




        }


        public ActionResult done()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult ContactList()
        {
            return View(PropertyDealer.ContactDetails.ToList());
        }

        // GET: Client/Delete/5
        public ActionResult Delete(ContactDetail C_ID)
        {

            var d = PropertyDealer.ContactDetails.Where(x => x.id == C_ID.id).FirstOrDefault();
            PropertyDealer.ContactDetails.Remove(d);
            PropertyDealer.SaveChanges();
            return RedirectToAction("ContactList");
        }

    }
}