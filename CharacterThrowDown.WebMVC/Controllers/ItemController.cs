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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ItemService(userId);

            service.CreateItem(model);
            return RedirectToAction("Index");
        }
    }
}