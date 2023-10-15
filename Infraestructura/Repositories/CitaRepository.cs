using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class CitaRepository : GenericRepository<Cita>,ICita
    {
        private readonly AnimalsVetContext _context;
        public CitaRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}