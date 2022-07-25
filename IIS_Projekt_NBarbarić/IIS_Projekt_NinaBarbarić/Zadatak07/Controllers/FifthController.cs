using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Zadatak07.Controllers
{
    public class FifthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowResult(string searchQuery)
        {
            var url = "http://localhost:8080/API_IIS/webresources/endpoints?cityName=" + searchQuery;

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            ViewBag.data = data;
            return View();
        }
    }
}
