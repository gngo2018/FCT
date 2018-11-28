using CharacterThrowdown.Models;
using CharacterThrowdown.Services;
using CharacterThrowDown.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharacterThrowDown.WebMVC.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            var model = service.GetCharacters();

            return View(model);
        }

        //GET: Create Character
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create Character
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateCharacterService();

            if (service.CreateCharacter(model))
            {
                TempData["SaveResult"] = "Your character is ready for battle!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Character was unable to be created, please try again");

            return View(model);
        }

        //GET: Character Details
        public ActionResult Details(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }

        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            return service;
        }

    }
}