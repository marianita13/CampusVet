using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class DepartamentoRepository: GenericRepository<Departamento>, IDepartamento
    {
        private readonly AnimalsVetContext _context;
        public DepartamentoRepository(AnimalsVetContext context) : base(context)
        {
            _context = context;
        }
    }
}