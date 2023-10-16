using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIVET.Controllers
{

    public class CiudadController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private IUnitOfWork _UnitOfWork;
        private IMapper _mapper;
        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Ciudad>>> Get(){
            var ciudades = await _UnitOfWork.Ciudades.GetAllAsync();
            return Ok(ciudades);
        }
    }
}