using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace Zadatak07.Controllers
{
    public class FourthController : Controller
    {
        public IActionResult Index()
        {
            var url = "http://localhost:8080/API_IIS/webresources/endpoints/jaxB";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            string[] lines = System.IO.File.ReadAllLines(@"D:\skola\IIS\JAXB_Result.txt");

            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                sb.Append(line);
            }

            ViewBag.data = sb;
            return View();
        }
    }
}
