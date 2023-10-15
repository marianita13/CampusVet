using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class ClienteTelRepository: GenericRepository<ClienteTelefono>,IClienteTel
    {
        private readonly AnimalsVetContext _context;
        public ClienteTelRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}