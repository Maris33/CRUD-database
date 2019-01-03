using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;
using ZooDb.ViewModels;

namespace ZooDb.Services
{
    public interface IAnimalTypeService
    {
         List<AnimalType> GetAllTypes();
        AnimalType GetSingleAnimalTypeById(int id);
    }
}
