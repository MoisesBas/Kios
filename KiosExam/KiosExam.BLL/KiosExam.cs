using KiosExam.DAL;
using KiosExam.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.BLL
{
    public class KiosExam : IKiosExam
    {
        private DAL.Interface.IKiosExamRepo _context;
        public KiosExam(HttpClient client)
        {
            _context = new KiosExamRepo(client);
        }

        public List<RootObject> GetItems(string url)
        {
            var response = _context.GetItems(url);
            return null;
            // return JsonConvert.DeserializeObject<RootObject>(response);
        }
    }
}
