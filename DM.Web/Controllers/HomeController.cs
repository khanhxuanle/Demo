using DM.Data;
using DM.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DM.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDMService _dmService;

        public HomeController(IDMService dmService)
        {
            this._dmService = dmService;
        }
        public ActionResult Index()
        {
            var listClass = _dmService.getAllClass();
            
            return View(listClass);
        }

        [HttpGet]
        public ActionResult EditClass(int IdClass)
        {
            var classObjectById = _dmService.getClassById(IdClass);
            return View(classObjectById);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClass(Class classObject)
        {
            _dmService.EditClass(classObject);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult NewClass()
        {
            var newClassObject = new Class();
            return View(newClassObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewClassObject(Class newClassObject)
        {
            var classOject = new Class {
                ClassName = newClassObject.ClassName,
                ClassDescription = newClassObject.ClassDescription
            };

            _dmService.InsertClass(classOject);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteClass(int IdClass)
        {
            _dmService.DeleteClass(IdClass);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}