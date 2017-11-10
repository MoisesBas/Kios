using KiosExam.DAL.Interface;
using KiosExam.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KiosExam.DAL
{
    public class KiosExamRepo : IKiosExamRepo
    {
        private readonly HttpClient _client;

        public KiosExamRepo()
        {
            var apiUrl = "https://api.stackexchange.com/2.2/questions?page=1&pagesize=50&order=desc&sort=creation&tagged=asp.net&site=stackoverflow";

            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            _client = new HttpClient(handler)
            {               
                BaseAddress = new Uri(apiUrl)
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));          
           
        }

        public string  GetItems(string url)
        {
            var response =  _client.GetStringAsync(url).Result;

            return response;
        }
    }
}
