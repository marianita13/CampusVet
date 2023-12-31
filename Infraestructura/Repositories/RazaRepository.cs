using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class RazaRepository: GenericRepository<Raza>, IRaza
    {
        private readonly AnimalsVetContext _context;
        public RazaRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}