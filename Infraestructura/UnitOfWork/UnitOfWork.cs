using Core.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repositories;

namespace Infraestructura.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AnimalsVetContext _context;
        public UnitOfWork(AnimalsVetContext context)
        {
            _context = context;
        }

        private ICita _Citas { get; set; }
        private ICiudad _Ciudades { get; set; }
        private ICliente _Clientes { get; set; }
        private IClienteDir _ClienteDirecciones { get; set; }
        private IClienteTel _ClienteTelefonos { get; set; }
        private IDepartamento _Departamentos { get; set; }
        private IMascota _Mascotas { get; set; }
        private IPais _Paises { get; set; }
        private IRaza _Razas { get; set; }
        private IServicio _Servicios { get; set; }

        // public ICita cita{
        //     get{
        //         if (_Citas == null){
        //             _Citas = new CitaRepository (_context);
        //         }
        //         return _Citas;
        //     }
        // }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}