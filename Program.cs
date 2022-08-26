using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.WriteLine($"Please enter your API Key");
            var api_Key = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Please neter the ciy name");
                var city_name = Console.ReadLine();
                var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";

                var response = client.GetStringAsync(weatherUrl).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine($"Would you like to choose a different city");

                var userInput = Console.ReadLine();
                Console.WriteLine();
                if(userInput.ToLower() == "no")
                {
                    break;
                }

            }
        }
    }
}
