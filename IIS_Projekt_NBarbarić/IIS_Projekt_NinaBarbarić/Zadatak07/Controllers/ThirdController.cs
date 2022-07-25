using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Zadatak07.Controllers
{
    public class ThirdController : Controller
    {
        public IActionResult ShowSearchBox()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowResult(string searchQuery)
        {
            ServiceReference1.SoapSoapClient service = new ServiceReference1.SoapSoapClient(ServiceReference1.SoapSoapClient.EndpointConfiguration.SoapSoap);

            string result = service.SearchAsync(searchQuery).Result.Body.SearchResult.InnerXml;

            ViewBag.data = result;
            return View();
        }
    }
}
