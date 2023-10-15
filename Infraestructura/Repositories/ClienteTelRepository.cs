using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class ClienteTelRepository: GenericRepository<ClienteTelefono>
    {
        private readonly AnimalsVetContext _context;
        public ClienteTelRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}