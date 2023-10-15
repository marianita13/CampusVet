using APIVET.Controllers;
using Core.entities;

namespace APIVET.Dtos
{
    public class ClienteDto : BaseController
    {
        public int Id {get; set;}
        public string NombreCliente { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public ICollection<ClienteTelefono> ClientesTelefonos { get; set; }         
        public ICollection<Mascota> Mascotas { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}