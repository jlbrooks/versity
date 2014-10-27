using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using versity.data.Models;
using versity.data.DataAccess;
using System.Linq;

namespace versity.Controllers
{
    public class APIController : Controller
    {
        public APIController(IItemStore itemStore, IMenuStore menuStore, IRestaurantStore restaurantStore)
        {
            _itemStore = itemStore;
            _menuStore = menuStore;
            _restaurantStore = restaurantStore;
        }

        public JsonResult SearchBudget(decimal budget)
        {
            var items = _itemStore.GetUnderPrice(budget);
            var translated = items.Select(x => mapItem(x));
            return new JsonResult { Data = translated, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // Returns a list of restaurants, with a list of items the fulfill the budget
        public JsonResult GetRestaurantsWithBudget(decimal budget)
        {
            var restaurants = _restaurantStore.HasItemUnderBudget(budget);
            var translated = restaurants.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                Items = x.Menus.First().Items.Where(i => i.Cost <= budget).Select(i => mapItem(i)),
                Lat = x.Locations.First().lat,
                Lng = x.Locations.First().lng
            });

            return new JsonResult
            {
                Data = translated,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        private object mapItem(Item i)
        {
            var obj = new
            {
                ID = i.ID,
                Name = i.Name,
                Description = i.Description,
                Cost = i.Cost,
                Category = i.Category
            };
            return obj;
        }

        private readonly IItemStore _itemStore;
        private readonly IMenuStore _menuStore;
        private readonly IRestaurantStore _restaurantStore;
    }
}