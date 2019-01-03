using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooDb.Models;
using ZooDb.Services;

namespace ZooDb.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalService _animalService;
        private IEmployeeService _employeeService;
        private IAnimalTypeService _animalTypeService;
        private IAviaryService _aviaryService;
        private IZooService _zooService;
        public AnimalController(IAnimalService animalService, IEmployeeService employeeService, IAnimalTypeService animalTypeService, IAviaryService aviaryService, IZooService zooService)
        {
            _animalService = animalService;
            _employeeService = employeeService;
            _animalTypeService = animalTypeService;
            _aviaryService = aviaryService;
            _zooService = zooService;
        }
        
        public IActionResult AllAnimals()
        {
            return View(_animalService.GetAllAnimals());
        }
        public IActionResult CreateAnimal()
        {
            ViewBag.Employees = _employeeService.GetAllEmployees();
            ViewBag.AnimalTypes = _animalTypeService.GetAllTypes();
            ViewBag.Aviaries = _aviaryService.GetAllAviaries();
            ViewBag.Zoos = _zooService.GetAllZoos();
            return View();
        }
        public IActionResult AnimalCreated(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Employees = _employeeService.GetAllEmployees();
                ViewBag.AnimalTypes = _animalTypeService.GetAllTypes();
                ViewBag.Aviaries = _aviaryService.GetAllAviaries();
                ViewBag.Zoos = _zooService.GetAllZoos();
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("CreateAnimal");
            }
            _animalService.AddAnimal(animal);
            return View();
        }
        public IActionResult EditAnimal(int id)
        {
            ViewBag.Employees = _employeeService.GetAllEmployees();
            ViewBag.AnimalTypes = _animalTypeService.GetAllTypes();
            ViewBag.Aviaries = _aviaryService.GetAllAviaries();
            ViewBag.Zoos = _zooService.GetAllZoos();
            return View(_animalService.GetSingleAnimalById(id));
        }

        public IActionResult AnimalEdited(Animal newAnimal)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                ViewBag.Employees = _employeeService.GetAllEmployees();
                ViewBag.AnimalTypes = _animalTypeService.GetAllTypes();
                ViewBag.Aviaries = _aviaryService.GetAllAviaries();
                ViewBag.Zoos = _zooService.GetAllZoos();
                return View("EditAnimal", newAnimal);
            }
            _animalService.UpdateAnimal(newAnimal);

            return View();
        }
        public IActionResult AnimalDetails(int id)
        {
            return View(_animalService.AnimalDetails(id));
        }

    }
}
