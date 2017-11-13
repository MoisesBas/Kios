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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="KiosExam.DAL.Interface.IKiosExamRepo" />
    public class KiosExamRepo : IKiosExamRepo
    {
        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;
        /// <summary>
        /// The root URL
        /// </summary>
        private string rootUrl = ConfigurationManager.AppSettings["KiosRoot"];
        /// <summary>
        /// Initializes a new instance of the <see cref="KiosExamRepo"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public string  GetItems(string url)
        {
            var response =  _client.GetStringAsync(url).Result;

            return response;
        }
    }
}
