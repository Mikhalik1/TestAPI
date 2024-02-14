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
    public class UsersController
    {
        public static List<Users> GetUsers(string login, string password)
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    string url=$"{Manager.RootUrl}/login/?login={login}&password={password}";
                    Console.WriteLine(url);
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    
                        var content = response.Content.ReadAsStringAsync();
                        var answer = JsonConvert.DeserializeObject<Response<List<Users>>>(content.Result);
                   
                        return answer.data;
                    
                }
            }
            catch { throw new Exception("Ошибка подключение к серверу"); }
        }
    }
}
