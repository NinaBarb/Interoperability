using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace Zadatak07.Controllers
{
    public class SixthController : Controller
    {
        public async Task<IActionResult> Index()
        {
            await getFreeGameData();

            ViewBag.resultBody = await getFreeGameData();
            return View();
        }

        private static async Task<List<Game>> getFreeGameData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://free-to-play-games-database.p.rapidapi.com/api/games"),
                Headers =
                {
                    { "X-RapidAPI-Key", "256f65ac4fmsh34770c7dd0cf340p196fd1jsn0c8e1606c2c7" },
                    { "X-RapidAPI-Host", "free-to-play-games-database.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var games = JsonConvert.DeserializeObject<List<Game>>(body);
                return games;
            }
        }
    }
}
