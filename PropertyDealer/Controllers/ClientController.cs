using PropertyDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyDealer.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        PropertyDealerEntities PropertyDealer = new PropertyDealerEntities();
        public ActionResult ClientList()
        {
            return View(PropertyDealer.Clients.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")]Client client)
        {

            if (!ModelState.IsValid)
                return View();
            PropertyDealer.Clients.Add(client);
            PropertyDealer.SaveChanges();
            return RedirectToAction("ClientList");
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var C_ID = (from m in PropertyDealer.Clients where m.id == id select m).First();
            return View(C_ID);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Client C_ID)
        {
            var orignalRecord = (from m in PropertyDealer.Clients where m.id == C_ID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            PropertyDealer.Entry(orignalRecord).CurrentValues.SetValues(C_ID);

            PropertyDealer.SaveChanges();
            return RedirectToAction("ClientList");


        }

        // GET: Client/Delete/5
        public ActionResult Delete(Client C_ID)
        {

            var d = PropertyDealer.Clients.Where(x => x.id == C_ID.id).FirstOrDefault();
            PropertyDealer.Clients.Remove(d);
            PropertyDealer.SaveChanges();
            return RedirectToAction("ClientList");
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
