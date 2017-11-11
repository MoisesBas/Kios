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
        int pagetotal = 1;
        int totalcount = 0;
        string responseStatus = "";
        string responseText = "";
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

        public ActionResult getItems(int page=1)
        {
            int pagesize = 20;
            Array data = null;
            var url = "https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow&filter=!9YdnSIN16";
            try
            {
                var result = _exam.GetItems(url);
                data = result.items.ToArray();
               
                responseStatus = "OK";
            }
            catch(Exception ex)
            {
                if (String.IsNullOrEmpty(ex.Message))
                    responseStatus = "ERROR";
                responseText = ex.Message;
            }
            return Json(new
            {
                pagesize,
                totalpages = pagetotal,
                recordcount = totalcount,
                page,
                status = responseStatus,
                message = responseText,
                data = data
            });

        }
    }
}