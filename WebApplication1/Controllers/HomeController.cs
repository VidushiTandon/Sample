using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        niitContext context;
        HomeService service;
        public HomeController(niitContext context)
        {
            this.context = context;
            service = new HomeService(this.context);
        }

        public IActionResult Index()
        {
            // service.Grouping();

            //int x = 12344;
            //int y = x.Reverse();
            //int z = IntegerExtender.Reverse(3456);

            service.ExtensionMethods();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            //niitContext ctx = new niitContext();
            //int x = ctx.Emp.Count();
            var result = service.GetEmpDepttDetails();
            return View(result);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            List<string> names = service.EmpNames();
            return View(names);
        }
        [HttpGet]
        public IActionResult NewEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewEmp(Emp em)
        {
             service.AddRecord(em);
            return RedirectToAction("About");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
