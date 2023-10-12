using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Pais : BaseEntity
    {
        //public readonly object Id;

        public string NombrePais {get; set;}
        public ICollection<Departamento> Departamentos { get; set; } 
        
    }
}