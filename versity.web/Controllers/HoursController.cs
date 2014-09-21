using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using versity.data.DataAccess.EntityFramework;
using versity.data.Models;
using versity.data.DataAccess;

namespace versity.Controllers
{
    [Authorize]
    public class HoursController : Controller
    {
        public HoursController(IHoursStore store)
        {
            _store = store;
        }

        // GET: Hours/Create
        public ActionResult Create(int restaurantId)
        {
            var Hours = new Hours { RestaurantID = restaurantId };
            return View(Hours);
        }

        // POST: Hours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,restaurantId,Day,Open,Closed")] Hours Hours)
        {
            if (ModelState.IsValid)
            {
                _store.Add(Hours);
                return RedirectToAction("Details", "Restaurants", new { id = Hours.RestaurantID });
            }

            return View(Hours);
        }

        // GET: Hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hours Hours = _store.GetByHoursID(id.Value);
            if (Hours == null)
            {
                return HttpNotFound();
            }
            return View(Hours);
        }

        // POST: Hours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,restaurantId,Day,Open,Closed")] Hours Hours)
        {
            if (ModelState.IsValid)
            {
                _store.Update(Hours);
                return RedirectToAction("Details", "Restaurants", new { id = Hours.RestaurantID });
            }
            return View(Hours);
        }

        // POST: Hours/Delete/5
        public ActionResult Delete(int id)
        {
            Hours Hours = _store.GetByHoursID(id);
            _store.Remove(id);
            return RedirectToAction("Details", "Restaurants", new { id = Hours.RestaurantID });
        }

        private readonly IHoursStore _store;
    }
}
