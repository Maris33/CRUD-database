using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;
using ZooDb.ViewModels;

namespace ZooDb.Services
{
    public interface IZooService
    {
        List<Zoo> GetAllZoos();
        void AddZoo(Zoo zoo);
        Zoo GetSingleZooById(int id);
        void UpdateZoo(Zoo newZoo);
        void DeleteZoo(int id);
        List<Employee> GetEmployeesByZooId(int zooId);
        List<Animal> GetAnimalsByZooId(int zooId);
        ZooViewModel ZooDeletionConfirmation(int id);
        ZooDetailsViewModel ZooDetails(int id);
    }
}
