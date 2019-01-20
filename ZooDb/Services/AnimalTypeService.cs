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
    public class AnimalTypeService : IAnimalTypeService
    {
        private ZooContext _context;
        private IAnimalService _animalService;
        public AnimalTypeService(ZooContext context, IAnimalService animalService)
        {
            _context = context;
            _animalService = animalService;
        }
        public List<AnimalType> GetAllTypes()
        {
            List<AnimalType> types = _context.AnimalTypes.ToList();
            return types;
        }
       
        public AnimalType GetSingleAnimalTypeById(int id) => _context.AnimalTypes.Where(n => n.Id == id).FirstOrDefault();

       
    }
}
