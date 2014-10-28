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

        // Returns a list of restaurants, all of which have >= 1 item that is under budget
        public JsonResult GetRestaurantsWithBudget(decimal budget)
        {
            var restaurants = _restaurantStore.HasItemUnderBudget(budget);
            var translated = restaurants.Select(r => mapRestaurant(r));

            return new JsonResult
            {
                Data = translated,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetRestaurantById(int id)
        {
            var restaurant = _restaurantStore.GetByRestaurantID(id);
            var translated = mapRestaurant(restaurant);

            return new JsonResult
            {
                Data = translated,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        private object mapRestaurant(Restaurant r)
        {
            var obj = new
            {
                ID = r.ID,
                Name = r.Name,
                PhoneNumber = r.PhoneNumber,
                Locations = r.Locations.Select(l => mapLocation(l)),
                Menus = r.Menus.Select(m => mapMenu(m))
            };
            return obj;
        }

        private object mapLocation(Location l)
        {
            var obj = new
            {
                ID = l.ID,
                Address = l.Address,
                City = l.City,
                State = l.State,
                Lat = l.lat,
                Lng = l.lng
            };
            return obj;
        }

        private object mapMenu(Menu m)
        {
            var obj = new
            {
                ID = m.ID,
                Name = m.Name,
                Active = m.Active,
                Items = m.Items.Select(i => mapItem(i))
            };
            return obj;
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