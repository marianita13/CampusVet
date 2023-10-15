using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIVET.Controllers;
using Core.entities;

namespace APIVET.Dtos
{
    public class RazaDto : BaseController
    {
        public int Id {get; set;}
        public string NombreRaza { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }
    }
}