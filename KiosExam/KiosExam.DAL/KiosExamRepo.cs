using KiosExam.DAL.Interface;
using KiosExam.DAL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private string rootUrl = ConfigurationManager.AppSettings["KiosRoot"];
        public KiosExamRepo()
        {          

            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            _client = new HttpClient(handler)
            {               
                BaseAddress = new Uri(rootUrl)
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
