using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class MyHttpClient
    {
        public HttpClient _httpClient;


        public MyHttpClient()
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress= new Uri("https://dog.ceo");

        }

        public async Task<string> GetDataAsync(string endpoint)
        {

            return await _httpClient.GetStringAsync(endpoint);

        }

    }
}
