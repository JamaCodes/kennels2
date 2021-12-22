using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Controllers
{
    public class WalkRequestController : Controller
    {
        // GET: WalkRequestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WalkRequestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalkRequestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
