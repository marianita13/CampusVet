using APIVET.Controllers;
using APIVET.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ClienteDirController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteDirController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDirDto>>> Get()
        {
            var ClienteDirDtoes = await _unitOfWork.ClienteDirecciones.GetAllAsync();
            return _mapper.Map<List<ClienteDirDto>>(ClienteDirDtoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDirDto>> Get(int id)
        {
            var ClienteDirDto = await _unitOfWork.ClienteDirecciones.GetIdAsync(id);
            if(ClienteDirDto == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteDirDto>(ClienteDirDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDirDto>> Post(ClienteDirDto ClienteDirDto)
        {
            var ClienteDir = _mapper.Map<ClienteDireccion>(ClienteDirDto);
            this._unitOfWork.ClienteDirecciones.Add(ClienteDir);
            await _unitOfWork.SaveAsync();
            if(ClienteDir == null)
            {
                return BadRequest();
            }
            ClienteDirDto.Id = ClienteDirDto.Id;
            return CreatedAtAction(nameof(Post), new {id = ClienteDirDto.Id}, ClienteDirDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDirDto>> Put(int id, [FromBody] ClienteDirDto ClienteDirDtoDto)
        {
            if(ClienteDirDtoDto == null)
            {
                return NotFound();
            }
            var ClienteDirDtoes = _mapper.Map<ClienteDireccion>(ClienteDirDtoDto);
            _unitOfWork.ClienteDirecciones.Update(ClienteDirDtoes);
            await _unitOfWork.SaveAsync();
            return ClienteDirDtoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ClienteDirDto = await _unitOfWork.ClienteDirecciones.GetIdAsync(id);
            if(ClienteDirDto == null)
            {
                return NotFound();
            }
            _unitOfWork.ClienteDirecciones.Remove(ClienteDirDto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }