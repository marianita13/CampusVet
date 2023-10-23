using APIVET.Controllers;
using APIVET.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class MascotaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
        {
            var Mascotaes = await _unitOfWork.Mascotas.GetAllAsync();
            return _mapper.Map<List<MascotaDto>>(Mascotaes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaDto>> Get(int id)
        {
            var Mascota = await _unitOfWork.Mascotas.GetIdAsync(id);
            if(Mascota == null)
            {
                return NotFound();
            }
            return _mapper.Map<MascotaDto>(Mascota);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MascotaDto>> Post(MascotaDto MascotaDto)
        {
            var Mascota = _mapper.Map<Mascota>(MascotaDto);
            this._unitOfWork.Mascotas.Add(Mascota);
            await _unitOfWork.SaveAsync();
            if(Mascota == null)
            {
                return BadRequest();
            }
            MascotaDto.Id = Mascota.Id;
            return CreatedAtAction(nameof(Post), new {id = MascotaDto.Id}, MascotaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody] MascotaDto MascotaDto)
        {
            if(MascotaDto == null)
            {
                return NotFound();
            }
            var Mascotaes = _mapper.Map<Mascota>(MascotaDto);
            _unitOfWork.Mascotas.Update(Mascotaes);
            await _unitOfWork.SaveAsync();
            return MascotaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Mascota = await _unitOfWork.Mascotas.GetIdAsync(id);
            if(Mascota == null)
            {
                return NotFound();
            }
            _unitOfWork.Mascotas.Remove(Mascota);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }