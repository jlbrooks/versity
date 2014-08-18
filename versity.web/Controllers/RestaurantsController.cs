using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using versity.data.DataAccess;
using versity.data.Models;
using versity.Models;

namespace versity.Controllers
{
    [Authorize]
    public class RestaurantsController : Controller
    {
        public RestaurantsController(IRestaurantStore store)
        {
            _store = store;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = _store.All();
            return View(model);
        }

        // Get: Restaurants/new
        public ActionResult New()
        {
            return View();
        }
        
        // Post: Restaurant/new
        [HttpPost]
        public ActionResult New(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _store.Add(restaurant);
                return RedirectToAction("Index");
            }
            else
            {
                return View(restaurant);
            }
        }

        // Get: Restaurants/edit/{id}
        public ActionResult Edit(int id)
        {
            var restaurant = _store.GetByRestaurantID(id);
            if (restaurant == null)
                return RedirectToAction("Index", "Restaurants");
            return View(restaurant);
        }

        //Post: Restaurants/edit/{id}
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return View(restaurant);
            _store.Update(restaurant);
            return RedirectToAction("Index");
        }

        // Post: Restaurants/delete/id
        public ActionResult Delete(int id)
        {
            _store.Remove(id);
            return RedirectToAction("Index");
        }

        // Get: Restaurants/details/id
        public ActionResult Details(int id)
        {
            var restaurant = _store.GetByRestaurantID(id);
            if (restaurant == null)
                return RedirectToAction("Index");
            return View(restaurant);
        }

        private readonly IRestaurantStore _store;
    }
}