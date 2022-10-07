using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace WebAPIClient
{
    class Pokemon
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("season")]
        public string Season { get; set; }
        [JsonProperty("season_week")]
        public string Season_Week { get; set; }
        

    }
    

    public class program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Do you want tomorrow's details? Type yes or press enter to to quit");

                    var userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        break;
                    }
                    var result = await client.GetAsync("http://calapi.inadiutorium.cz/api/v0/en/calendars/general-en/tomorrow");
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var tomorrow = JsonConvert.DeserializeObject<Pokemon>(resultRead);

                    Console.WriteLine("---");
                    Console.WriteLine("Date: " + tomorrow.Date);
                    Console.WriteLine("Season:  " + tomorrow.Season);
                    Console.WriteLine("Season Week: " + tomorrow.Season_Week);

                }
                catch (Exception)
                {
                    //Console.WriteLine("Error. Please enter a valid Pokemon name");
                    //Console.WriteLine("Error");
                }
            }
        }
    }



}