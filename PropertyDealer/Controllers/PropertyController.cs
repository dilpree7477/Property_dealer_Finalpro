using PropertyDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyDealer.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Client
        PropertyDealerEntities PropertyDealer = new PropertyDealerEntities();
        public ActionResult PropertyList()
        {
            return View(PropertyDealer.PropertyDetails.ToList());
        }

        public ActionResult ServiceList()
        {
            return View(PropertyDealer.PropertyDetails.ToList());
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
        public ActionResult Create([Bind(Exclude = "id")]PropertyDetail propertyDetails)
        {

            if (!ModelState.IsValid)
                return View();
            PropertyDealer.PropertyDetails.Add(propertyDetails);
            PropertyDealer.SaveChanges();
            return RedirectToAction("PropertyList");
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var P_ID = (from m in PropertyDealer.PropertyDetails where m.id == id select m).First();
            return View(P_ID);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(PropertyDetail P_ID)
        {
            var orignalRecord = (from m in PropertyDealer.PropertyDetails where m.id == P_ID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            PropertyDealer.Entry(orignalRecord).CurrentValues.SetValues(P_ID);

            PropertyDealer.SaveChanges();
            return RedirectToAction("PropertyList");


        }

        // GET: Client/Delete/5
        public ActionResult Delete(PropertyDetail P_ID)
        {

            var d = PropertyDealer.PropertyDetails.Where(x => x.id == P_ID.id).FirstOrDefault();
            PropertyDealer.PropertyDetails.Remove(d);
            PropertyDealer.SaveChanges();
            return RedirectToAction("PropertyList");
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
