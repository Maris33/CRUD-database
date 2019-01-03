using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.Services
{
    public interface IAviaryService
    {
     
        List<Aviary> GetAllAviaries();
        Aviary GetSingleAviaryById(int id);
    }
}
