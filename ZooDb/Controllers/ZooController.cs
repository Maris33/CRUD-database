using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooDb.Models;
using ZooDb.Services;

namespace ZooDb.Controllers
{
    public class ZooController : Controller
    {
        private IZooService _zooService;
        public ZooController(IZooService zooService)
        {
            _zooService = zooService;
        }
        
        public IActionResult All()
        {
            return View(_zooService.GetAllZoos());
        }
        public IActionResult CreateZoo() => View();
        public IActionResult ZooCreated(Zoo zoo)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateZoo");
            }
            _zooService.AddZoo(zoo);
            return View();
        }
        public IActionResult EditZoo(int id) => View(_zooService.GetSingleZooById(id));
        
        public IActionResult ZooEdited(Zoo newZoo)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditZoo", newZoo);
            }
            _zooService.UpdateZoo(newZoo);

            return View();
        }

        public IActionResult DeleteZoo(int id) => View(_zooService.ZooDeletionConfirmation(id));


        public IActionResult ZooDeleted(int id)
        {
            _zooService.DeleteZoo(id);
            return View();
        }
        public IActionResult ZooDetails(int id)
        {
            return View(_zooService.ZooDetails(id));
        }
    }
}
