using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Raza : BaseEntity
    {
        //public readonly object Id;

        public string NombreRaza { get; set; }

        public ICollection<Mascota> Mascotas { get; set; } 
    }
}