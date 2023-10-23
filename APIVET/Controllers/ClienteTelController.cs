using APIVET.Controllers;
using APIVET.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ClienteTelController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteTelController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteTelDto>>> Get()
        {
            var ClienteTelDtoes = await _unitOfWork.ClienteTelefonos.GetAllAsync();
            return _mapper.Map<List<ClienteTelDto>>(ClienteTelDtoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteTelDto>> Get(int id)
        {
            var ClienteTelDto = await _unitOfWork.ClienteTelefonos.GetIdAsync(id);
            if(ClienteTelDto == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteTelDto>(ClienteTelDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteTelDto>> Post(ClienteTelDto ClienteTelDtoDto)
        {
            var ClienteTelDto = _mapper.Map<ClienteTelefono>(ClienteTelDtoDto);
            this._unitOfWork.ClienteTelefonos.Add(ClienteTelDto);
            await _unitOfWork.SaveAsync();
            if(ClienteTelDto == null)
            {
                return BadRequest();
            }
            ClienteTelDtoDto.Id = ClienteTelDto.Id;
            return CreatedAtAction(nameof(Post), new {id = ClienteTelDtoDto.Id}, ClienteTelDtoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteTelDto>> Put(int id, [FromBody] ClienteTelDto ClienteTelDtoDto)
        {
            if(ClienteTelDtoDto == null)
            {
                return NotFound();
            }
            var ClienteTelDtoes = _mapper.Map<ClienteTelefono>(ClienteTelDtoDto);
            _unitOfWork.ClienteTelefonos.Update(ClienteTelDtoes);
            await _unitOfWork.SaveAsync();
            return ClienteTelDtoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ClienteTelDto = await _unitOfWork.ClienteTelefonos.GetIdAsync(id);
            if(ClienteTelDto == null)
            {
                return NotFound();
            }
            _unitOfWork.ClienteTelefonos.Remove(ClienteTelDto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }