using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Data;
using ZooDb.Models;
using ZooDb.ViewModels;

namespace ZooDb.Services
{
    public class AnimalService : IAnimalService
    {
        private ZooContext _context;
        public AnimalService(ZooContext context)
        {
            _context = context;
        }
        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        /*public void DeleteAnimal(int id)
        {
            Animal animalToBeDeleted = GetSingleAnimalById(id);
            _context.Animals.Remove(animalToBeDeleted);
            _context.SaveChanges();
        }*/

        public List<Animal> GetAllAnimals()
        {
            List<Animal> animals = _context.Animals.Include(n => n.Employee).Include(r => r.AnimalType).Include(y => y.Aviary).Include(e => e.Zoo).ToList();
            return animals;
        }

        public Animal GetSingleAnimalById(int id) => _context.Animals.Where(n => n.Id == id).FirstOrDefault();
        


        public void UpdateAnimal(Animal newAnimal)
        {
            Animal oldAnimal = GetSingleAnimalById(newAnimal.Id);
            oldAnimal.Name = newAnimal.Name;
           oldAnimal.AnimalTypeId = newAnimal.AnimalTypeId;
            oldAnimal.AviaryId = newAnimal.AviaryId;
            oldAnimal.MaleFemale = newAnimal.MaleFemale;
            oldAnimal.Growth = newAnimal.Growth;
            oldAnimal.Weight = newAnimal.Weight;
            oldAnimal.Age = newAnimal.Age;
            oldAnimal.Birthday = newAnimal.Birthday;
            oldAnimal.EmployeeId = newAnimal.EmployeeId;
            oldAnimal.ZooId = newAnimal.ZooId;
            _context.SaveChanges();
        }

        /* public AnimalViewModel AnimalDeletionConfirmation(int id)
         {

             Animal animal = GetSingleAnimalById(id);
             AnimalViewModel animalVM = new AnimalViewModel()
             {
                 Id = animal.Id,
                 StudentName = animal.FullName
             };

             return animalVM;

         }*/

        public AnimalDetailsViewModel AnimalDetails(int id)
        {
            Animal animal = GetSingleAnimalById(id);
            AnimalDetailsViewModel animalVM = new AnimalDetailsViewModel()

            {
                Id = animal.Id,
                AnimalName = animal.Name,
                _AnimalType = new AnimalTypeService(_context).GetSingleAnimalTypeById(animal.AnimalTypeId),
                _Aviary = new AviaryService(_context).GetSingleAviaryById(animal.AviaryId),
                AnimalSex = animal.MaleFemale,
                AnimalGrowth = animal.Growth,
                AnimalWeight = animal.Weight,
                AnimalAge = animal.Age,
                AnimalBirthday = animal.Birthday,
                _Employee = new EmployeeService(_context).GetSingleEmployeeById(animal.EmployeeId),
               _Zoo = new ZooService(_context).GetSingleZooById(animal.ZooId)

            };
            return animalVM;

        }
    }
}
