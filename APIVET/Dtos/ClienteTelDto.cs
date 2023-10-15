using APIVET.Controllers;

namespace APIVET.Dtos
{
    public class ClienteTelDto : BaseController
    {
        public int Id {get; set;}
        public int IdCliente { get; set; }
        public string Numero { get; set; }
    }
}