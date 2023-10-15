using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class CiudadRepository: GenericRepository<Ciudad>
    {
        private readonly AnimalsVetContext _context;
        public CiudadRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}