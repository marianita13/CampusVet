using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APIVET.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIVET.Controllers
{
    public class DepartamentoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get(){
            var departamento = await _unitOfWork.Departamentos.GetAllAsync();
            return Ok(departamento);   
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DepartamentoDto>> GetId(int id){
            var departamento = await _unitOfWork.Departamentos.GetIdAsync(id);
            if (departamento == null){
                return NotFound();
            }
            return Ok(departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DepartamentoDto>> Post(DepartamentoDto departamentoDto, int id){
            var departamento = _mapper.Map<Departamento>(departamentoDto);
            if (departamento == null){
                return BadRequest();
            }
            _unitOfWork.Departamentos.Add(departamento);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new {id = departamentoDto.Id}, departamentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DepartamentoDto>> Put(int id, DepartamentoDto departamentoDto){
            if (departamentoDto.Id == 0){
                departamentoDto.Id = id;
            }
            if (departamentoDto.Id != id){
                return BadRequest();
            }
            if (departamentoDto == null){
                return NotFound();
            }
            var departamento = _mapper.Map<Departamento>(departamentoDto);
            _unitOfWork.Departamentos.Update(departamento);
            await _unitOfWork.SaveAsync();
            return departamentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var departamento = await _unitOfWork.Departamentos.GetIdAsync(id);
            if (departamento == null){
                return NotFound();
            }
            _unitOfWork.Departamentos.Remove(departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
