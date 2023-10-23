using APIVET.Controllers;
using APIVET.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class RazaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
        {
            var Razaes = await _unitOfWork.Razas.GetAllAsync();
            return _mapper.Map<List<RazaDto>>(Razaes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RazaDto>> Get(int id)
        {
            var Raza = await _unitOfWork.Razas.GetIdAsync(id);
            if(Raza == null)
            {
                return NotFound();
            }
            return _mapper.Map<RazaDto>(Raza);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RazaDto>> Post(RazaDto RazaDto)
        {
            var Raza = _mapper.Map<Raza>(RazaDto);
            this._unitOfWork.Razas.Add(Raza);
            await _unitOfWork.SaveAsync();
            if(Raza == null)
            {
                return BadRequest();
            }
            RazaDto.Id = Raza.Id;
            return CreatedAtAction(nameof(Post), new {id = RazaDto.Id}, RazaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RazaDto>> Put(int id, [FromBody] RazaDto RazaDto)
        {
            if(RazaDto == null)
            {
                return NotFound();
            }
            var Razaes = _mapper.Map<Raza>(RazaDto);
            _unitOfWork.Razas.Update(Razaes);
            await _unitOfWork.SaveAsync();
            return RazaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Raza = await _unitOfWork.Razas.GetIdAsync(id);
            if(Raza == null)
            {
                return NotFound();
            }
            _unitOfWork.Razas.Remove(Raza);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }