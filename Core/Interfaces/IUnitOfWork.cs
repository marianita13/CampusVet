using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICita Citas {get;}
        ICiudad Ciudades {get;}
        ICliente Clientes {get;}
        IClienteDir ClienteDirecciones {get;}
        IClienteTel ClienteTelefonos {get;}
        IDepartamento Departamentos {get;}
        IMascota Mascotas {get;}
        IPais Paises {get;}
        IRaza Razas {get;}
        IServicio Servicios {get;}
        Task<int> SaveAsync();
    }
}