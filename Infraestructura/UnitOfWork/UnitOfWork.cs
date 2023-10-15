using System.Diagnostics.CodeAnalysis;
using Core.entities;
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

        private ICita _Citas;
        private ICiudad _Ciudades;
        private ICliente _Clientes;
        private IClienteDir _ClienteDirecciones;
        private IClienteTel _ClienteTelefonos;
        private IDepartamento _Departamentos;
        private IMascota _Mascotas;
        private IPais _Paises;
        private IRaza _Razas;
        private IServicio _Servicios;

        public ICita Cita{
            get{
                if (_Citas == null){
                    _Citas = new CitaRepository(_context);
                }
                return _Citas;
            }
        }
        public ICiudad ciudad{
            get{
                if (_Ciudades == null){
                    _Ciudades = new CiudadRepository(_context);
                }
                return _Ciudades;
            }
        }
        public ICliente cliente{
            get{
                if(_Clientes == null){
                    _Clientes = new ClienteRepository(_context);
                }
                return _Clientes;
            }
        }
        public IClienteDir clienteDir{
            get{
                if(_ClienteDirecciones == null){
                    _ClienteDirecciones = new ClienteDirRepository(_context);
                }
                return _ClienteDirecciones;
            }
        }
        public IClienteTel clienteTel{
            get{
                if(_ClienteTelefonos == null){
                    _ClienteTelefonos = new ClienteTelRepository(_context);
                }
                return _ClienteTelefonos;
            }
        }
        public IDepartamento departamento{
            get{
                if(_Departamentos == null){
                    _Departamentos =  new DepartamentoRepository(_context);
                }
                return _Departamentos;
            }
        }
        public IMascota mascota{
            get{
                if(_Mascotas == null){
                    _Mascotas = new MascotaRepository(_context);
                }
                return _Mascotas;
            }
        }
        public IPais pais{
            get{
                if(_Paises == null){
                    _Paises = new PaisRepository(_context);
                }
                return _Paises;
            }
        }
        public IRaza raza{
            get{
                if(_Razas == null){
                    _Razas = new RazaRepository(_context);
                }
                return _Razas;
            }
        }
        public IServicio servicio{
            get{
                if(_Servicios == null){
                    _Servicios = new ServicioRepository(_context);
                }
                return _Servicios;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public Task<int> SaveAsync(){
            return _context.SaveChangesAsync();
        }
    }
}