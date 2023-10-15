using APIVET.Controllers;
using Core.entities;

namespace APIVET.Dtos
{
    public class PaisDto : BaseController
    {
        public int Id { get; set; }
        public string NombrePais { get; set; }
        public ICollection<Departamento> Departamentos { get; set; } 
    }
}