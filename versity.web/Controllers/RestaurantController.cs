using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using versity.data.DataAccess;
using versity.data.Models;

namespace versity.Controllers
{
    public class RestaurantController : Controller
    {
        public RestaurantController(IRestaurantStore store)
        {
            _store = store;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(_store.All());
        }

        private readonly IRestaurantStore _store;
    }
}