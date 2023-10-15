using APIVET.Controllers;
using Core.entities;

namespace APIVET.Dtos
{
    public class MascotaDto : BaseController
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int IdRaza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdCliente { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}