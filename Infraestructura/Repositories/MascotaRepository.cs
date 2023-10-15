using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class MascotaRepository: GenericRepository<Mascota>, IMascota
    {
        private readonly AnimalsVetContext _context;
        public MascotaRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}