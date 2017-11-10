using KiosExam.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.BLL
{
    public interface IKiosExam
    {
        RootObject[] GetItems(string url);
    }
}
