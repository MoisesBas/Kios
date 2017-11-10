using KiosExam.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.DAL.Interface
{
    public interface IKiosExamRepo
    {
        string GetItems(string url);
    }
}