using Microsoft.AspNetCore.Mvc;
using Zadatak05.Models;
using System.Xml;

namespace Zadatak05.Controllers
{
    public class XmlRpcController : Controller
    {
        String URLString = "https://vrijeme.hr/hrvatska_n.xml";

        public IActionResult Index()
        {
            XmlTextReader reader = new XmlTextReader(URLString);
            while (reader.Read())
            {
                // Do some work here on the data.
                Console.WriteLine(reader.Name);
            }
            Console.ReadLine();

            return View();
        }
    }
}
