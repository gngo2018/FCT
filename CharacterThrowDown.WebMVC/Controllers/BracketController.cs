using CharacterThrowdown.Models;
using CharacterThrowdown.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharacterThrowDown.WebMVC.Controllers
{
    public class BracketController : Controller
    {
        // GET: Bracket
        public ActionResult Index()
        {
            var service = new BracketService();
            var model = service.GetBrackets();

            return View(model);
        }

        //GET: Create Bracket
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create Bracket
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BracketCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new BracketService();

            if (service.CreateBracket(model))
            {
                TempData["SaveResult"] = "Your Battle is set! May the best character win!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Battle was unable to be created, please try again");

            return View(model);
        }
    }
}
