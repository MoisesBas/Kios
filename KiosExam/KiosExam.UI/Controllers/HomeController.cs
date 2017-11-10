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
            string apiUrl = "https://api.stackexchange.com/2.2/questions?page=1&pagesize=50&order=desc&sort=creation&tagged=asp.net&site=stackoverflow";
            var result = _exam.GetItems(apiUrl);
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