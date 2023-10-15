using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class MascotaRepository: GenericRepository<Mascota>
    {
        private readonly AnimalsVetContext _context;
        public MascotaRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}