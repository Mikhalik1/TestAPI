using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class Wantedcontoller
    {
        public static List<Wanted> GetWanted()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{Manager.RootUrl}/wanted";
                    Console.WriteLine(url);
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync();
                        var answer = JsonConvert.DeserializeObject<Response<List<Wanted>>>(content.Result);

                        return answer.data;
                    }
                    else return null;


                }
            }
            catch { throw new Exception("Ошибка подключение к серверу"); }
        }
    }
}
