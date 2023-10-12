using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Servicio : BaseEntity
    {
        //public readonly object Id;

        [Required]
        public string Nombre { get; set; }

        [Required]
        public double Precio { get; set; }
        public ICollection<Cita> Citas { get; set; } 
    }
}