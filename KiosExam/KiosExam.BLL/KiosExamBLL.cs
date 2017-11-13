using KiosExam.DAL;
using KiosExam.DAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.BLL
{
    public class KiosExamBLL : IKiosExam
    {
        private DAL.Interface.IKiosExamRepo _context;

        
        public KiosExamBLL(DAL.Interface.IKiosExamRepo repo)
        {
            _context = repo;
        }

        public QuestionObject GetItems(string url)
        {
            var response = _context.GetItems(url);
            return JsonConvert.DeserializeObject<QuestionObject>(response);


        }
        public AnswerObject GetAnswer(string url)
        {
            var response = _context.GetItems(url);
            return JsonConvert.DeserializeObject<AnswerObject>(response);


        }
        public CommentObject GetComment(string url)
        {
            var response = _context.GetItems(url);
            return JsonConvert.DeserializeObject<CommentObject>(response);

        }
    }
}
