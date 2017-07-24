using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using Diplom.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        ExSystem EX = new ExSystem();
        public bool selector = false;

        public ActionResult Index()
        {
            ViewBag.Message = "Главная страница";
            return View();
        }

        [HttpGet]
        public ActionResult ExSystem(int? i, bool? result)
        {
                EX.Question(0);
                return View(EX);
        }

        [HttpPost]
        public JsonResult ExS(int i, bool? result)
        {
            selector = result.HasValue;
            if (!selector)
            {
                EX.Question(i);
                return Json(EX);
            }
            else
            {
                i++;
                EX.Question(i);
                return Json(EX);
            }
        }

        public ActionResult EXSResult(int price,bool[] answers)
        {
            EX.answers = answers;
            EX.PC(EX.answers, price);
            return PartialView(EX);
        }

        public ActionResult Guide()
        {
            return View();
        }


    }
}