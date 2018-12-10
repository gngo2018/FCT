using CharacterThrowdown.Models;
using CharacterThrowdown.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharacterThrowDown.WebMVC.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            var model = service.GetItems();
            return View(model);
        }

        //GET: Item Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Item Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateItemService();

            if (service.CreateItem(model))
            {
                TempData["SaveResult"] = "Your item is ready to use!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Item could not be created");

            return View(model);
        }

        //GET Item Detail
        public ActionResult Details (int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        //GET: Item Edit
        public ActionResult Edit(int id)
        {
            var service = CreateItemService();
            var detail = service.GetItemById(id);
            var model =
                new ItemEdit
                {
                    ItemId = detail.ItemId,
                    ItemName = detail.ItemName,
                    ItemDescription = detail.ItemDescription,
                    ItemType = detail.ItemType
                };
            return View(model);
        }

        //POST: Item Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateItemService();

            if (service.UpdateItem(model))
            {
                TempData["SaveResult"] = "Your item was updated! Hopefully it does better this time...";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your item could not be updated. Please try again.");

            return View(model);
        }

        //GET Item Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateItemService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        //POST: Item Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost (int id)
        {
            var service = CreateItemService();

            service.DeleteItem(id);

            TempData["SaveResult"] = "Your item was Deleted! Time for a new one!";

            return RedirectToAction("Index");
        }

        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);
            return service;
        }
    }
}