using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class SomthingController : Controller
    {
        // GET: Somthing
        public ActionResult Index()
        {
            return View();
        }

        // GET: Somthing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Somthing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Somthing/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Somthing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Somthing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Somthing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Somthing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
