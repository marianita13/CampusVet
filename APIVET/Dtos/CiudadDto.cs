using APIVET.Controllers;
using Core.entities;

namespace APIVET.Dtos
{
    public class CiudadDto : BaseController
    {
        public int Id {get; set;}
        public string NombreCiudad { get; set; }
        public int IdDep { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}