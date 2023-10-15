using APIVET.Controllers;
using Core.entities;

namespace APIVET.Dtos
{
    public class ServicioDto : BaseController
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}