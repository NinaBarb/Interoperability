using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Zadatak07.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult ShowForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Game game)
        {
            if (!ModelState.IsValid)
            {
                return View("ShowForm", game);
            }

            var url = "http://localhost:5076/api/Rng";

            var request = WebRequest.Create(url);
            request.Method = "POST";

            var json = JsonSerializer.Serialize(game);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();

            return RedirectToAction("ShowData", new { data = data });
        }

        public IActionResult ShowData(string data)
        {
            ViewBag.data = data;
            return View();
        }
    }
}
