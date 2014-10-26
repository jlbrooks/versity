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
using versity.External;

namespace versity.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        public LocationsController(ILocationStore store, IGeocoder geocoder)
        {
            _store = store;
            _geocoder = geocoder;
        }

        // GET: Locations/Create
        public ActionResult Create(int restaurantId)
        {
            var Locations = new Location { RestaurantID = restaurantId };
            return View(Locations);
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RestaurantID,Address,City,State,Zip")] Location Location)
        {
            var latlng = _geocoder.GeocodeAddress(Location.Address, Location.City, Location.State, Location.Zip);
            Location.lat = latlng.Item1;
            Location.lng = latlng.Item2;
            if (ModelState.IsValid)
            {
                _store.Add(Location);
                return RedirectToAction("Details", "Restaurants", new { id = Location.RestaurantID });
            }

            return View(Location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location Location = _store.GetByLocationID(id.Value);
            if (Location == null)
            {
                return HttpNotFound();
            }
            return View(Location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RestaurantID,Address,City,State,Zip")] Location Location)
        {
            var latlng = _geocoder.GeocodeAddress(Location.Address, Location.City, Location.State, Location.Zip);
            Location.lat = latlng.Item1;
            Location.lng = latlng.Item2;
            if (ModelState.IsValid)
            {
                _store.Update(Location);
                return RedirectToAction("Details", "Restaurants", new { id = Location.RestaurantID });
            }
            return View(Location);
        }

        // POST: Locations/Delete/5
        public ActionResult Delete(int id)
        {
            Location Location = _store.GetByLocationID(id);
            _store.Remove(id);
            return RedirectToAction("Details", "Restaurants", new { id = Location.RestaurantID });
        }

        private readonly ILocationStore _store;
        private readonly IGeocoder _geocoder;
    }
}
