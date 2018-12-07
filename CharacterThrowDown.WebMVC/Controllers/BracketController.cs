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
            var service = new BracketService();
            var characterList = new SelectList(service.Characters(), "CharacterId", "CharacterName");
            ViewBag.FirstCharacterEightId = characterList;
            ViewBag.SecondCharacterEightId = characterList;
            ViewBag.ThirdCharacterEightId = characterList;
            ViewBag.FourthCharacterEightId = characterList;
            ViewBag.FifthCharacterEightId = characterList;
            ViewBag.SixthCharacterEightId = characterList;
            ViewBag.SeventhCharacterEightId = characterList;
            ViewBag.EighthCharacterEightId = characterList;

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

            var svc = new BracketService();
            ViewBag.FirstCharacterEightId = new SelectList(svc.Characters(), "FirstCharacterEightId", "CharacterName", model.FirstCharacterEightId);
            ViewBag.SecondCharacterEightId = new SelectList(svc.Characters(), "SecondCharacterEightId", "CharacterName", model.SecondCharacterEightId);
            ViewBag.ThirdCharacterEightId = new SelectList(svc.Characters(), "ThirdCharacterEightId", "CharacterName", model.ThirdCharacterEightId);
            ViewBag.FourthCharacterEightId = new SelectList(svc.Characters(), "FourthCharacterEightId", "CharacterName", model.FourthCharacterEightId);
            ViewBag.FifthCharacterEightId = new SelectList(svc.Characters(), "FifthCharacterEightId", "CharacterName", model.FifthCharacterEightId);
            ViewBag.SixthCharacterEightId = new SelectList(svc.Characters(), "SixthCharacterEightId", "CharacterName", model.SixthCharacterEightId);
            ViewBag.SeventhCharacterEightId = new SelectList(svc.Characters(), "SeventhCharacterEightId", "CharacterName", model.SeventhCharacterEightId);
            ViewBag.EighthCharacterEightId = new SelectList(svc.Characters(), "EighthCharacterEightId", "CharacterName", model.EighthCharacterEightId);


            return View(model);
        }

        //POST: Bracket Details
        public ActionResult Details(int id)
        {
            var svc = new BracketService();
            var model = svc.GetBracketById(id);
            if (!ModelState.IsValid) return View(model);

            return View(model);
        }

        //GET: Bracket Edit

        //POST: Bracket Edit

        //GET: Battle Delete
        public ActionResult Delete(int id)
        {
            var svc = new BracketService();
            var model = svc.GetBracketById(id);

            return View(model);
        }

        //POST: Bracket Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new BracketService();

            service.DeleteBracket(id);

            TempData["SaveResult"] = "Your Character was deleted. Shame... they had no choice.";
            return RedirectToAction("Index");
        }
    }
}
