using KiosExam.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.DAL
{
    public class KiosExamRepo : IKiosExamRepo
    {
        private readonly HttpClient _client;

        public KiosExamRepo(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetItems(string url)
        {
            return await _client.GetStringAsync(url);
        }
    }
}
