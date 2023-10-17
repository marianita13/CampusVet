using APIVET.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIVET.Controllers
{

    public class CiudadController : BaseController
    {
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

        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get(){
            var ciudades = await _UnitOfWork.Ciudades.GetAllAsync();
            return Ok(ciudades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CiudadDto>> GetId(int id){
            var ciudades = await _UnitOfWork.Ciudades.GetIdAsync(id);
            if (ciudades == null){
                return NotFound();
            }
            return Ok(ciudades);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CiudadDto>> Post(CiudadDto ciudadDto){
            var ciudades = _mapper.Map<Ciudad>(ciudadDto);
            _UnitOfWork.Ciudades.Add(ciudades);
            await _UnitOfWork.SaveAsync();
            if (ciudades == null){
                return BadRequest();
            }
            ciudadDto.Id = ciudades.Id;
            return CreatedAtAction(nameof(Post), new {id = ciudadDto.Id}, ciudadDto); 
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CiudadDto>> Put(CiudadDto ciudadDto, int id){
            if (ciudadDto == null){
                return NotFound();
            }
            if (ciudadDto.Id == 0){
                ciudadDto.Id = id;
            }
            if (ciudadDto.Id != id){
                return BadRequest();
            }

            var ciudades = _mapper.Map<Ciudad>(ciudadDto);
            _UnitOfWork.Ciudades.Update(ciudades);
            await _UnitOfWork.SaveAsync();
            return ciudadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var ciudades = await _UnitOfWork.Ciudades.GetIdAsync(id);
            if (ciudades == null){
                return NotFound();
            }
            _UnitOfWork.Ciudades.Remove(ciudades);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}