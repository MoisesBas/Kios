using KiosExam.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKiosExam
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        QuestionObject GetItems(string url);
        /// <summary>
        /// Gets the answer.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        AnswerObject GetAnswer(string url);
        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        CommentObject GetComment(string url);
    }
}
