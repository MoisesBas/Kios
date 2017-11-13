using KiosExam.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.DAL.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKiosExamRepo
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        string GetItems(string url);
    }
}