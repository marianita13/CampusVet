using APIVET.Controllers;
using Core.entities;

namespace APIVET.Dtos
{
    public class DepartamentoDto : BaseController
    {
        public int Id {get; set;}
        public string NombreDep { get; set; }
        public int IdPais { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; } 
    }
}