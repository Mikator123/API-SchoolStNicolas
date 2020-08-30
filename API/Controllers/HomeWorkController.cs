using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HomeWorkController : Controller
    {
        // GET: HomeWorkController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeWorkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeWorkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeWorkController/Create
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

        // GET: HomeWorkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeWorkController/Edit/5
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

        // GET: HomeWorkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeWorkController/Delete/5
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
