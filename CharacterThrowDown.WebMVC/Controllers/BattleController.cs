using CharacterThrowdown.Data;
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
    public class BattleController : Controller
    {
        // GET: Battle
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BattleService(userId);
            var model = service.GetBattles();
            
            //var characters = db.Characters.Include(c => c. )

            return View(model);
        }

        //GET: Create Battle
        public ActionResult Create()
        {
            var characterList = new SelectList(db.Characters, "CharacterId", "CharacterName");
            ViewBag.FirstCharacterId = characterList;
            ViewBag.SecondCharacterId = characterList;

            var itemList = new SelectList(db.Items, "ItemId", "ItemName");
            ViewBag.FirstItemId = itemList;
            ViewBag.SecondItemId = itemList;
            return View();
        }

        //POST: Create Battle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BattleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBattleService();

            if (service.CreateBattle(model))
            {
                TempData["SaveResult"] = "Your Battle is set! May the best character win!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Battle was unable to be created, please try again");

            ViewBag.FirstCharacterId = new SelectList(db.Characters, "FirstCharacterId", "CharacterName", model.FirstCharacterId);
            ViewBag.SecondCharacterId = new SelectList(db.Characters, "SecondCharacterId", "CharacterName", model.SecondCharacterId);
            ViewBag.FirstItemId = new SelectList(db.Items, "FirstItemId", "ItemName", model.FirstItemId);
            ViewBag.SecondItemId = new SelectList(db.Items, "SecondItemId", "ItemName", model.SecondItemId);

            return View(model);
        }

        //POST: Battle Details
        public ActionResult Details(int id)
        {
            var svc = CreateBattleService();
            var model = svc.GetBattleById(id);
            if (!ModelState.IsValid) return View(model);       

            return View(model);
        }

        //GET: Battle Edit
        public ActionResult Edit (int id)
        {
            var characterList = new SelectList(db.Characters, "CharacterId", "CharacterName");
            ViewBag.FirstCharacterId = characterList;
            ViewBag.SecondCharacterId = characterList;

            var itemList = new SelectList(db.Items, "ItemId", "ItemName");
            ViewBag.FirstItemId = itemList;
            ViewBag.SecondItemId = itemList;

            var service = CreateBattleService();
            var detail = service.GetBattleById(id);
            var model =
                new BattleEdit
                {
                    BattleId = detail.BattleId,
                    BattleName = detail.BattleName,
                    Location = detail.Location,
                    FirstCharacterId = detail.FirstCharacterId,
                    SecondCharacterId = detail.SecondCharacterId,
                    FirstItemId = detail.FirstItemId,
                    SecondItemId = detail.SecondItemId,
                    WinnerCharacterId = detail.WinnerCharacterId
                };
            return View(model);
        }

        //POST: Battle Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, BattleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BattleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            Battle battle = db.Battles.Find(id);
            var service = CreateBattleService();
            
            if (service.UpdateBattle(model))
            {
                TempData["SaveResult"] = "Your Battle was updated! May the odds ever be in your favor.";
                return RedirectToAction("Index");
            }

            ViewBag.FirstCharacterId = new SelectList(db.Characters, "FirstCharacterId", "CharacterName", model.FirstCharacterId);
            ViewBag.SecondCharacterId = new SelectList(db.Characters, "SecondCharacterId", "CharacterName", model.SecondCharacterId);
            ViewBag.WinnerCharacterId = new SelectList(db.Characters, "WinnerCharacterId", "CharacterName", model.WinnerCharacterId);
            ViewBag.FirstItemId = new SelectList(db.Items, "FirstItemId", "ItemName", model.FirstItemId);
            ViewBag.SecondItemId = new SelectList(db.Items, "SecondItemId", "ItemName", model.SecondItemId);

            ModelState.AddModelError("", "Your Battle could not be updated");
            return View(model);

        }


        //GET: Battle Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateBattleService();
            var model = svc.GetBattleById(id);

            return View(model);
        }

        //POST: Battle Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBattleService();

            service.DeleteBattle(id);

            TempData["SaveResult"] = "Your Battle was deleted. Shame... would've been a great bout.";
            return RedirectToAction("Index");
        }

        //private CharacterService CreateCharacterService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new CharacterService(userId);
        //    return service;
        //}

        private BattleService CreateBattleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BattleService(userId);
            return service;
        }

        private ApplicationDbContext db = new ApplicationDbContext();
    }
}