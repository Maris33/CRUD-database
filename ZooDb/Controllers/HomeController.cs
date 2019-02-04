using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooDb.Data;
using ZooDb.Models;
using ZooDb.Services;
using ZooDb.ViewModels;

namespace ZooDb.Controllers
{
    public class HomeController : Controller
    {
        private IAnimalTypeService _animaltypeService;
        public HomeController(IAnimalTypeService animaltypeService)
        {
            _animaltypeService = animaltypeService;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel._AnimalTypes = _animaltypeService.GetAllTypes();

            return View(homeViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        
    }
}
