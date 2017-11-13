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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="KiosExam.BLL.IKiosExam" />
    public class KiosExamBLL : IKiosExam
    {
        /// <summary>
        /// The context
        /// </summary>
        private DAL.Interface.IKiosExamRepo _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="KiosExamBLL"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        public KiosExamBLL(DAL.Interface.IKiosExamRepo repo)
        {
            _context = repo;
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public QuestionObject GetItems(string url)
        {
            var response = _context.GetItems(url);
            return JsonConvert.DeserializeObject<QuestionObject>(response);


        }
        /// <summary>
        /// Gets the answer.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public AnswerObject GetAnswer(string url)
        {
            var response = _context.GetItems(url);
            return JsonConvert.DeserializeObject<AnswerObject>(response);


        }
        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public CommentObject GetComment(string url)
        {
            var response = _context.GetItems(url);
            return JsonConvert.DeserializeObject<CommentObject>(response);

        }
    }
}
