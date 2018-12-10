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
    [Authorize]
    public class BattleController : Controller
    {
        // GET: Battle
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BattleService(userId);
            var model = service.GetBattles();
        
            return View(model);
        }

        //GET: Create Battle
        public ActionResult Create()
        {
            var svc = CreateBattleService();
            var characterList = new SelectList(svc.Characters(), "CharacterId", "CharacterName");
            ViewBag.FirstCharacterId = characterList;
            ViewBag.SecondCharacterId = characterList;

            var itemList = new SelectList(svc.Items(), "ItemId", "ItemName");
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

            var svc = CreateBattleService();

            if (svc.CreateBattle(model))
            {
                TempData["SaveResult"] = "Your Battle is set! May the best character win!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Battle was unable to be created, please try again");

            ViewBag.FirstCharacterId = new SelectList(svc.Characters(), "FirstCharacterId", "CharacterName", model.FirstCharacterId);
            ViewBag.SecondCharacterId = new SelectList(svc.Characters(), "SecondCharacterId", "CharacterName", model.SecondCharacterId);
            ViewBag.FirstItemId = new SelectList(svc.Items(), "FirstItemId", "ItemName", model.FirstItemId);
            ViewBag.SecondItemId = new SelectList(svc.Items(), "SecondItemId", "ItemName", model.SecondItemId);

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
            var svc = CreateBattleService();
            var characterList = new SelectList(svc.Characters(), "CharacterId", "CharacterName");
            ViewBag.FirstCharacterId = characterList;
            ViewBag.SecondCharacterId = characterList;

            var itemList = new SelectList(svc.Items(), "ItemId", "ItemName");
            ViewBag.FirstItemId = itemList;
            ViewBag.SecondItemId = itemList;

            var detail = svc.GetBattleById(id);
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
            var svc = CreateBattleService();

            if (!ModelState.IsValid) return View(model);

            if (model.BattleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            
            if (svc.UpdateBattle(model))
            {
                TempData["SaveResult"] = "Your Battle was updated! May the odds ever be in your favor.";
                return RedirectToAction("Index");
            }

            ViewBag.FirstCharacterId = new SelectList(svc.Characters(), "FirstCharacterId", "CharacterName", model.FirstCharacterId);
            ViewBag.SecondCharacterId = new SelectList(svc.Characters(), "SecondCharacterId", "CharacterName", model.SecondCharacterId);
            ViewBag.WinnerCharacterId = new SelectList(svc.Characters(), "WinnerCharacterId", "CharacterName", model.WinnerCharacterId);
            ViewBag.FirstItemId = new SelectList(svc.Items(), "FirstItemId", "ItemName", model.FirstItemId);
            ViewBag.SecondItemId = new SelectList(svc.Items(), "SecondItemId", "ItemName", model.SecondItemId);

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

        private BattleService CreateBattleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BattleService(userId);
            return service;
        }
    }
}