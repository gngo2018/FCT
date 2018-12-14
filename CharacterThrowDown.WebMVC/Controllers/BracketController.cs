using CharacterThrowdown.Data;
using CharacterThrowdown.Models;
using CharacterThrowdown.Services;
using CharacterThrowDown.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            var characterService = CreateCharacterService();
            if (characterService.GetCharacters().Count() == 0)
            {
                return RedirectToAction("Create", "Character");
            }
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
            var svc = new BracketService();

            if (!ModelState.IsValid) return View(model);

            if (svc.CreateBracket(model))
            {
                TempData["SaveResult"] = "Your Bracket is set! May the best character win!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Bracket was unable to be created, please try again");

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
        public ActionResult Edit(int id)
        {
            var db = new BracketService();
            var detail = db.GetBracketById(id);
            var characterList = new SelectList(db.Characters(), "CharacterId", "CharacterName");
            ViewBag.FirstCharacterId = characterList;
            ViewBag.SecondCharacterId = characterList;
            ViewBag.ThirdCharacterId = characterList;
            ViewBag.FourthCharacterId = characterList;
            ViewBag.FifthCharacterId = characterList;
            ViewBag.SixthCharacterId = characterList;
            ViewBag.SeventhCharacterId = characterList;
            ViewBag.EighthCharacterId = characterList;

            var model =
                new BracketEdit
                {
                    BracketId = detail.BracketId,
                    Location = detail.Location,
                    TournamentName = detail.TournamentName,
                    FirstCharacterId = detail.FirstCharacterEightId,
                    SecondCharacterId = detail.SecondCharacterEightId,
                    ThirdCharacterId = detail.ThirdCharacterEightId,
                    FourthCharacterId = detail.FourthCharacterEightId,
                    FifthCharacterId = detail.FifthCharacterEightId,
                    SixthCharacterId = detail.SixthCharacterEightId,
                    SeventhCharacterId = detail.SeventhCharacterEightId,
                    EighthCharacterId = detail.EighthCharacterEightId,

                };
            return View(model);
        }

        //POST: Bracket Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BracketEdit model)
        {
            var svc = new BracketService();

            if (!ModelState.IsValid) return View(model);

            if (model.BracketId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }            

            if (svc.UpdateBracket(model))
            {
                TempData["SaveResult"] = "Your Bracket was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Battle could not be updated");
            return View(model);

        }
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

        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            return service;
        }
    }
}
