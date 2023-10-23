using APIVET.Controllers;
using APIVET.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ServicioController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ServicioDto>>> Get()
        {
            var Servicioes = await _unitOfWork.Servicios.GetAllAsync();
            return _mapper.Map<List<ServicioDto>>(Servicioes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServicioDto>> Get(int id)
        {
            var Servicio = await _unitOfWork.Servicios.GetIdAsync(id);
            if(Servicio == null)
            {
                return NotFound();
            }
            return _mapper.Map<ServicioDto>(Servicio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServicioDto>> Post(ServicioDto ServicioDto)
        {
            var Servicio = _mapper.Map<Servicio>(ServicioDto);
            this._unitOfWork.Servicios.Add(Servicio);
            await _unitOfWork.SaveAsync();
            if(Servicio == null)
            {
                return BadRequest();
            }
            ServicioDto.Id = Servicio.Id;
            return CreatedAtAction(nameof(Post), new {id = ServicioDto.Id}, ServicioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServicioDto>> Put(int id, [FromBody] ServicioDto ServicioDto)
        {
            if(ServicioDto == null)
            {
                return NotFound();
            }
            var Servicioes = _mapper.Map<Servicio>(ServicioDto);
            _unitOfWork.Servicios.Update(Servicioes);
            await _unitOfWork.SaveAsync();
            return ServicioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Servicio = await _unitOfWork.Servicios.GetIdAsync(id);
            if(Servicio == null)
            {
                return NotFound();
            }
            _unitOfWork.Servicios.Remove(Servicio);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }