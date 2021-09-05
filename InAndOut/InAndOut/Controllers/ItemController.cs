using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> Objs = _db.Items;
            return View(Objs);
        }
        //GET Create
        public IActionResult Create()
        {
           
            return View();
        }
        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
      //Get Delete
        public IActionResult Delete( int? id)
        {
            if(id==null || id ==0)
            {
                return NotFound();
            }
           var obj = _db.Items.Find(id);
            if (obj != null)
            {
               
                return View(obj);
            }
            return NotFound();
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.Items.Find(id);
            if (obj != null)
            {
                _db.Items.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();

        }
        //Get Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj != null)
            {

                return View(obj);
            }
            return NotFound();

        }
        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            _db.Items.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
