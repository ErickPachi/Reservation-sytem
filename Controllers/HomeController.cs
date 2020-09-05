using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeanSceneDipAssT2.Models;
using Microsoft.AspNetCore.Identity;
using BeanSceneDipAssT2.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BeanSceneDipAssT2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _logger = logger;
        }
       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Menu()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
