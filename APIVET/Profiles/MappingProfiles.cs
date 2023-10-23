using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIVET.Dtos;
using AutoMapper;
using Core.entities;

namespace APIVET.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
            {
                CreateMap<Pais,PaisDto>().ReverseMap();
                CreateMap<Departamento,DepartamentoDto>().ReverseMap();
                CreateMap<Ciudad,CiudadDto>().ReverseMap();
                CreateMap<ClienteDireccion,ClienteDirDto>().ReverseMap();
                CreateMap<ClienteTelefono,ClienteTelDto>().ReverseMap();
                CreateMap<Mascota,MascotaDto>().ReverseMap();
                CreateMap<Raza,RazaDto>().ReverseMap();
                CreateMap<Servicio,ServicioDto>().ReverseMap();
            }
    }
}