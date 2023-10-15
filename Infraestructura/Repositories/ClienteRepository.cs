using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class ClienteRepository: GenericRepository<Cliente>
    {
        private readonly AnimalsVetContext _context;
        public ClienteRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}