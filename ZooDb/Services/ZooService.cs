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
    public class ZooService : IZooService
    {
        private ZooContext _context;
        public ZooService(ZooContext context)
        {
            _context = context;
        }
        public void AddZoo(Zoo zoo)
        {
            _context.Zoos.Add(zoo);
            _context.SaveChanges();
        }
        
        public List<Zoo> GetAllZoos()
        {
            return _context.Zoos.Include(n => n.Employees).Include(c => c.Animals).ToList();
        }

        public Zoo GetSingleZooById(int id) => _context.Zoos.Where(n => n.Id == id).FirstOrDefault();
        public List<Employee> GetEmployeesByZooId(int zooId) => _context.Employees.Where(n => n.ZooId == zooId).ToList();
        public List<Animal> GetAnimalsByZooId(int zooId) => _context.Animals.Where(n => n.ZooId == zooId).ToList();

        public void UpdateZoo(Zoo newZoo)
        {
            Zoo oldZoo = GetSingleZooById(newZoo.Id);
            oldZoo.Name = newZoo.Name;
            oldZoo.Address = newZoo.Address;
            oldZoo.FoundingYear = newZoo.FoundingYear;
          
            _context.SaveChanges();
        }

       /* public void DeleteZoo(int id)
        {
            Zoo zooToBeDeleted = GetSingleZooById(id);
            _context.Zoos.Remove(zooToBeDeleted);
            _context.SaveChanges();
        }

        public ZooViewModel ZooDeletionConfirmation(int id)
        {

            Zoo zoo = GetSingleZooById(id);
            ZooViewModel zooVM = new ZooViewModel()
            {
                Id = zoo.Id,
                ZooName = zoo.Name
            };

            return zooVM;

        }*/

        public ZooDetailsViewModel ZooDetails(int id)
        {
            Zoo zoo = GetSingleZooById(id);
            ZooDetailsViewModel zooVM = new ZooDetailsViewModel()

            {
                Id = zoo.Id,
                ZooName = zoo.Name,
                ZooAddress = zoo.Address,
                ZooFoundingYear = zoo.FoundingYear,
                Animals = GetAnimalsByZooId(id),
                Employees = GetEmployeesByZooId(id)
            };
            return zooVM;

        }
    }
}
