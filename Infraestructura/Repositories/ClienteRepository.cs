using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class ClienteRepository: GenericRepository<Cliente>, ICliente
    {
        private readonly AnimalsVetContext _context;
        public ClienteRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}