using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using versity.data.DataAccess;
using versity.data.Models;

namespace versity.Controllers
{
    [Authorize]
    public class MenusController : Controller
    {
        public MenusController(IMenuStore menuStore)
        {
            _menuStore = menuStore;
        }

        // GET: /menus/{id}
        public ActionResult Details(int menuId)
        {
            var menu = _menuStore.GetByMenuID(menuId);
            return View(menu);
        }

        // GET: /menus/new/{restaurantId}
        public ActionResult New(int restaurantId)
        {
            var menu = new Menu { RestaurantID = restaurantId };
            return View(menu);
        }

        // Post: /menus/new
        [HttpPost]
        public ActionResult New(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _menuStore.Add(menu);
                return RedirectToAction("Details", "Restaurants", new { id = menu.RestaurantID});
            }
            else
            {
                return View(menu);
            }
        }

        // Post: /restaurants/{id}/menus/remove/{id}
        public ActionResult Delete(int menuId)
        {
            var menu = _menuStore.GetByMenuID(menuId);
            _menuStore.Remove(menuId);
            return RedirectToAction("Details", "Restaurants", new {id = menu.RestaurantID});
        }

        // Get: menus/edit/{id}
        public ActionResult Edit(int menuId)
        {
            var menu = _menuStore.GetByMenuID(menuId);
            if (menu == null)
                return RedirectToAction("Details", "Restaurants", new { id = menu.RestaurantID });
            return View(menu);
        }

        //Post: menus/edit/{id}
        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (!ModelState.IsValid)
                return View(menu);
            _menuStore.Update(menu);
            return RedirectToAction("Details", new { menuId = menu.ID});
        }

        private readonly IMenuStore _menuStore;
    }
}