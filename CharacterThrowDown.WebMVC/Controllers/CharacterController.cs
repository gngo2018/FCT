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
            //ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName");

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

        //GET: Character Edit
        public ActionResult Edit(int id)
        {
            //var itemList = new SelectList(db.Items, "ItemId", "ItemName");
            //ViewBag.ItemId = itemList;
            var service = CreateCharacterService();
            var detail = service.GetCharacterById(id);

            var model =
                new CharacterEdit
                {
                    CharacterId = detail.CharacterId,
                    CharacterName = detail.CharacterName,
                    CharacterUniverse = detail.CharacterUniverse,
                    CharacterAbility = detail.CharacterAbility,
                    //ItemId = detail.ItemId
                    
                };

            return View(model);
        }

        //POST: Character Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CharacterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
           
            var service = CreateCharacterService();
           // Character character = db.Characters.Find(id);

           // var list = new List<Item>();
           // foreach(var c in db.Characters)
           // {
           //     list.Add(c.Item);
           // }

            if (service.UpdateCharacter(model))
            {
                TempData["SaveResult"] = "Your Character was updated.";
                return RedirectToAction("Index");
            }

            //ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName", character.ItemId);

            ModelState.AddModelError("", "Your Character could not be updated");
            return View(model);
        }

        //GET: Character Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCharacterService();

            service.DeleteCharacter(id);

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