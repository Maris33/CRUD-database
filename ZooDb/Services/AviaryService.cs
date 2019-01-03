using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Data;
using ZooDb.Models;

namespace ZooDb.Services
{
    public class AviaryService : IAviaryService
    {
        private ZooContext _context;
        public AviaryService(ZooContext context)
        {
            _context = context;
        }
        public List<Aviary> GetAllAviaries()
        {
            List<Aviary> aviaries = _context.Aviaries.ToList();
            return aviaries;
        }
        public Aviary GetSingleAviaryById(int id) => _context.Aviaries.Where(n => n.Id == id).FirstOrDefault();
    }
}
