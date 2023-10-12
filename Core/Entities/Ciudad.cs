using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Ciudad : BaseEntity
    {
        //public readonly object Id;

        public string NombreCiudad { get; set; }

        public int IdDep { get; set; }
        public Departamento Departamentos { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ClienteDireccion ClienteDireccion { get; set; }
    }
}