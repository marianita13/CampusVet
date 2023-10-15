using APIVET.Controllers;

namespace APIVET.Dtos
{
    public class ClienteDirDto : BaseController
    {
        public int Id {get; set;}
        public int IdCliente { get; set; }
        public int IdCiudad { get; set; }
        public string TipoDeVia { get; set; }
        public int NumeroPri { get; set; }
        public int NumeroSec { get; set; }
        public int NumeroTer { get; set; }
    }
}