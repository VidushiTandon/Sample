using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.models.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        niitContext context;
        public DefaultController(niitContext context)

        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = (from c in context.Emp select new { c.Code, c.Name }).ToList();
            SelectList list = new SelectList(result, "Code","Name");
            ViewData["list"] = list;
            return View();

        }
        [HttpPost]
        public void GetCode(int EmpCode)
        {

        }
        

    }
    public class EmpDetails
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }

}

           
        
    
