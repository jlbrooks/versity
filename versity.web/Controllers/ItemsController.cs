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
    public class ItemsController : Controller
    {
        public ItemsController(IItemStore store)
        {
            _store = store;
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _store.GetByItemID(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create(int menuId)
        {
            var Item = new Item { MenuID = menuId };
            return View(Item);
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MenuID,Name,Cost,Category,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                _store.Add(item);
                return RedirectToAction("Details", "Menus", new { menuId = item.MenuID });
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _store.GetByItemID(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MenuID,Name,Cost,Category,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                _store.Update(item);
                return RedirectToAction("Details", "Menus", new { menuId = item.MenuID });
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = _store.GetByItemID(id);
            _store.Remove(id);
            return RedirectToAction("Details", "Menus", new { menuId = item.MenuID });
        }

        private readonly IItemStore _store;
    }
}
