using APIVET.Dtos;
using APIVET.Controllers;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Core.entities;

namespace API.Controllers;
public class CitaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CitaDto>>> Get()
        {
            var Citaes = await _unitOfWork.Citas.GetAllAsync();
            return _mapper.Map<List<CitaDto>>(Citaes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CitaDto>> Get(int id)
        {
            var Cita = await _unitOfWork.Citas.GetIdAsync(id);
            if(Cita == null)
            {
                return NotFound();
            }
            return _mapper.Map<CitaDto>(Cita);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CitaDto>> Post(CitaDto CitaDto)
        {
            var Cita = _mapper.Map<Cita>(CitaDto);
            this._unitOfWork.Citas.Add(Cita);
            await _unitOfWork.SaveAsync();
            if(Cita == null)
            {
                return BadRequest();
            }
            CitaDto.Id = Cita.Id;
            return CreatedAtAction(nameof(Post), new {id = CitaDto.Id}, CitaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CitaDto>> Put(int id, [FromBody] CitaDto CitaDto)
        {
            if(CitaDto == null)
            {
                return NotFound();
            }
            var Citaes = _mapper.Map<Cita>(CitaDto);
            _unitOfWork.Citas.Update(Citaes);
            await _unitOfWork.SaveAsync();
            return CitaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Cita = await _unitOfWork.Citas.GetIdAsync(id);
            if(Cita == null)
            {
                return NotFound();
            }
            _unitOfWork.Citas.Remove(Cita);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }