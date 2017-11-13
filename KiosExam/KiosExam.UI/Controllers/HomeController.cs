﻿using KiosExam.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using KiosExam.DAL.Model;

namespace KiosExam.UI.Controllers
{
    public class HomeController :Controller
    {
        protected readonly IKiosExam _exam;
        int pagetotal = 1;
        int totalcount = 0;
        int page = 1;
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

        public ActionResult Question()
        {
            return View();

        }

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