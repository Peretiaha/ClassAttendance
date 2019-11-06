using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public IActionResult Index()
        {
            return View();
        }

       public IActionResult Details()
        {
            return View();
        }
    }
}