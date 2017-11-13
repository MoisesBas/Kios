using KiosExam.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using KiosExam.DAL.Model;

namespace KiosExam.UI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController :Controller
    {
        /// <summary>
        /// The exam
        /// </summary>
        protected readonly IKiosExam _exam;
        /// <summary>
        /// The pagetotal
        /// </summary>
        int pagetotal = 1;
        /// <summary>
        /// The totalcount
        /// </summary>
        int totalcount = 0;
        /// <summary>
        /// The page
        /// </summary>
        int page = 1;
        /// <summary>
        /// The response status
        /// </summary>
        string responseStatus = "";
        /// <summary>
        /// The response text
        /// </summary>
        string responseText = "";
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="exam">The exam.</param>
        public HomeController(IKiosExam exam)
        {
            _exam = exam;

        }
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {            
            return View();
        }


        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Questions this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Question()
        {
            return View();

        }

        /// <summary>
        /// Gets the answer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult getAnswer(int id)
        {
            Array data = null;            
            var answer = new AnswerObject();          
            var url = string.Empty;
            try
            {
                if (id != 0)
                {
                    
                    answer = _exam.GetAnswer(string.Format("questions/{0}/answers?page=1&pagesize=50&order=desc&sort=creation&site=stackoverflow&filter=!b0OfNR*gZdUEwX", id));
                    data = answer.items.ToArray();                   

                }
                responseStatus = "OK";
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(ex.Message))
                    responseStatus = "ERROR";
                responseText = ex.Message;
            }
            return Json(new
            {                 
                status = responseStatus,
                message = responseText,
                data                
            });
        }

        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult getComment(int id)
        {            
            Array data = null;            
            var comment = new CommentObject();
            var url = string.Empty;
            try
            {
                if (id != 0)
                {                    
                    comment = _exam.GetComment(string.Format("questions/{0}/comments?order=desc&sort=creation&site=stackoverflow&filter=!9YdnSQVog", id));
                    data = comment.items.ToArray();

                }
                responseStatus = "OK";
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(ex.Message))
                    responseStatus = "ERROR";
                responseText = ex.Message;
            }
            return Json(new
            {               
                status = responseStatus,
                message = responseText,
                data                
            });
        }

        /// <summary>
        /// Getitems the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult getitem(int id)
        {
            int totalpages = 1, pagesize = 50, recordcount = 0;
            Array data = null,arrdata1 = null,arrdata2=null;
            var question = new QuestionObject();            
            var url = string.Empty;
            try
            {
                if (id != 0) {
                    question = _exam.GetItems(string.Format("questions/{0}?order=desc&sort=activity&site=stackoverflow&filter=!b0OfNINZfha_h*", id));
                    data = question.items.ToArray();                    

                }
                responseStatus = "OK";
            }            
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(ex.Message))
                    responseStatus = "ERROR";
                responseText = ex.Message;
            }
            return Json(new
            {
                pagesize,
                totalpages,
                recordcount,
                page,
                status = responseStatus,
                message = responseText,
                data
                
            });
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public ActionResult getItems(string search ="", int page = 1)
        {
            
            int totalpages = 1, pagesize = 50, recordcount = 0;
            Array data = null;
            var result = new QuestionObject();
            var url = string.Empty;
            try
            {                

                url = !string.IsNullOrEmpty(search)? String.Format("search?page={0}&pagesize={1}&order=desc&sort=creation&intitle={2}&site=stackoverflow&filter=!-*f(6rc.bgwz",page,pagesize, search):
                   String.Format("questions?page={0}&pagesize={1}&order=desc&sort=creation&site=stackoverflow&filter=!-*f(6rc.bgwz",page,pagesize);
                result = _exam.GetItems(url);                
                if(result.total != 0)
                {
                    recordcount = result.total;
                    
                    totalpages = (int)Math.Ceiling(((float)recordcount / (float)pagesize));
                    page = page < 1 ? 1 : page;
                    page = page > totalpages ? totalpages : page;

                }
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
                totalpages,
                recordcount,
                page,
                status = responseStatus,
                message = responseText,
                data = data
            });

        }
    }
}