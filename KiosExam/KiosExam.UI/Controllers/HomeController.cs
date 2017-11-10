using KiosExam.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiosExam.UI.Controllers
{
    public class HomeController :Controller
    {
        protected readonly IKiosExam _exam;
        public HomeController(IKiosExam exam)
        {
            _exam = exam;

        }
        public ActionResult Index()
        {            
            return View();
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