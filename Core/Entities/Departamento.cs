using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Departamento : BaseEntity
    {
        //public readonly object Id;

        public string NombreDep { get; set; }
        public int IdPais { get; set; }
        public Pais Paises { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; } 
    }
}