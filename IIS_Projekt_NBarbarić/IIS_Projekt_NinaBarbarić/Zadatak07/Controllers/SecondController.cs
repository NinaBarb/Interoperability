using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Utils;
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

            string data = Api.getContent(url, game);

            return RedirectToAction("ShowData", new { data = data });
        }

        public IActionResult ShowData(string data)
        {
            ViewBag.data = data;
            return View();
        }
    }
}
