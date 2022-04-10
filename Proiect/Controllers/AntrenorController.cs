using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Entities.DTOs;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntrenorController : ControllerBase
    {
        private readonly IAntrenorRepository _repository;

        public AntrenorController(IAntrenorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllAntrenors()
        {
            try
            {
                var antrenors = _repository.GetAll();
                var retAntrenors = new List<AntrenorDTO>();

                foreach (var ant in antrenors)
                {
                    retAntrenors.Add(new AntrenorDTO(ant));
                }
                return Ok(retAntrenors);
                }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost("fromBody")]
        public async Task<IActionResult> CreateAntrenor(CreateAntrenorDTO dto)
        {
            Antrenor ant = new Antrenor();

            ant.varsta = dto.varsta;
            ant.telefon = dto.telefon;
            ant.Nume = dto.Nume;
            ant.Email = dto.Email;
            ant.Optiuni = dto.Optiuni;
            ant.OmId = dto.OmId;

             _repository.Create(ant);
            await _repository.SaveAsync();
            return Ok(new AntrenorDTO(ant));
        }
        // public async Task<IActionResult> CreateAntrenor( CreateAntrenorDTO dto)
        //{
        //  Antrenor ant = new Antrenor();

        //ant.varsta = dto.varsta;
        //ant.telefon = dto.telefon;
        //ant.Nume = dto.Nume;
        //ant.Email = dto.Email;
        //ant.Optiuni = dto.Optiuni;
        //ant.OmId = dto.OmId;

        // _repository.Create(ant);
        //await _repository.SaveAsync();
        //return Ok(new AntrenorDTO(ant));
        //}

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAntrenorByName(string name)
        {
            try
            {
                var antrenor = await _repository.GetByName(name);

                return Ok(new AntrenorDTO(antrenor));
            }
            catch(Exception e)
            {
                return Ok();
            }
        }
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetAntrenorById(int id)
        {
            try
            {
                var antrenor = await _repository.GetById(id);

                return Ok(new AntrenorDTO(antrenor));
            }
            catch (Exception e)
            {
                return Ok();
            }
        }
        [HttpDelete("")]
        public async Task<IActionResult> DeleteAntrenor([FromBody] Antrenor antrenor)
        {
            if (antrenor != null)
            {
                _repository.Delete(antrenor);
                await _repository.SaveAsync();
                return NoContent();
            }
            return NotFound("nu exista");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAntrenorById(int id)
        {
            var antrenor = await _repository.GetByIdAsync(id);
            if(antrenor != null)
            {
                _repository.Delete(antrenor);
                await _repository.SaveAsync();
                return NoContent();
            }
            return NotFound("nu exista");
        }
        [HttpPut]
        public async Task<IActionResult> ChangeEmail([FromBody] Antrenor ant)
        {
            try
            {
                _repository.Update(ant);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
