using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static async Task CheckHosts()
        {
            HttpClient client = new HttpClient();
            string[] urls = {
            "https://www.teammodel.net",
            "https://sokrates.teammodel.org",            
            "https://sokapp5.teammodel.net",           
        };

            foreach (string url in urls)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"{url} is reachable. Status code: {response.StatusCode}");
                    }
                    else
                    {
                        Console.WriteLine($"{url} is not reachable. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"{url} is not reachable: {e.Message}");
                }
            }
        }
        static void Main(string[] args)
        {
            CheckHosts().Wait();          
            Console.ReadLine();
        }
    }
}
