using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class CiudadRepository: GenericRepository<Ciudad>,ICiudad
    {
        private readonly AnimalsVetContext _context;
        public CiudadRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}