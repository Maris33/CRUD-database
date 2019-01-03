using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;
using ZooDb.ViewModels;

namespace ZooDb.Services
{
    public interface IAnimalService
    {
        List<Animal> GetAllAnimals();
        void AddAnimal(Animal animal);
        Animal GetSingleAnimalById(int id);
        void UpdateAnimal(Animal newAnimal);
        //void DeleteAnimal(int id);
        AnimalDetailsViewModel AnimalDetails(int id);
        /*AnimalViewModel AnimalDeletionConfirmation(int id);*/
    }
}
