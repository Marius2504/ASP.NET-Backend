using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Entities.DTOs;
using Proiect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Entities;
using System.Transactions;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerRepository _repository;

        public TrainerController(ITrainerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainers()
        {
            try
            {
                var trainers = _repository.GetAll();
                var retTrainers = new List<TrainerDTO>();

                foreach (var trainer in trainers)
                    retTrainers.Add(new TrainerDTO(trainer));

                return Ok(retTrainers);
            }
            catch
            {
                return NoContent();
            }
        }

        //get all trainers grouped by age
        [HttpGet("grouped")]
        public IActionResult GetGrouped()
        {
            try
            {
                var trainers = _repository.GetAllGroupByAge();

                return Ok(trainers);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        // get all trainers that have an account
        [HttpGet("Account-Trainer")]
        public IActionResult GetAccountTrainers()
        {
            try
            {
                var trainers = _repository.GetAllAccountTrainers();
                //var retAntrenors = new List<AntrenorDTO>();

                //foreach (var ant in antrenors)
                //{
                //  retAntrenors.Add(new AntrenorDTO(ant));
                //}
                return Ok(trainers);
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpGet("getFirst/{nr}")]
        public IActionResult GetFirstAntrenors(int nr)
        {
            try
            {
                var trainers = _repository.GetFirst(nr);
                var retTrainers = new List<TrainerDTO>();

                foreach (var trainer in trainers)
                {
                    retTrainers.Add(new TrainerDTO(trainer));
                }
                return Ok(retTrainers);
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpPost("fromBody")]
        public async Task<IActionResult> CreateTrainer(Trainer dto)
        {

            Trainer ant = new Trainer();

            ant.Age = dto.Age;
            ant.PhoneNumber = dto.PhoneNumber;
            ant.Name = dto.Name;
            ant.Email = dto.Email;
            ant.Options = dto.Options;

            _repository.Create(ant);
            await _repository.SaveAsync();
            ant = await _repository.GetByIdAsync(ant.Id);

            if (dto.Clients != null)
            {
                foreach (var client in dto.Clients)
                {
                    ant.Clients.Add(client);
                }
            }
            if (dto.TrainerGyms != null)
            {
                foreach (var trainerGym in dto.TrainerGyms)
                {
                    ant.TrainerGyms.Add(trainerGym);
                }
            }
            await _repository.SaveAsync();

            return Ok(new TrainerDTO(ant));
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetTrainerByName(string name)
        {
            try
            {
                var trainer = await _repository.GetByName(name);

                return Ok(new TrainerDTO(trainer));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            try
            {
                var trainer = await _repository.GetById(id);

                return Ok(new TrainerDTO(trainer));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpDelete("")]
        public async Task<IActionResult> DeleteAntrenor([FromBody] Trainer trainer)
        {
            if (trainer != null)
            {
                _repository.Delete(trainer);
                await _repository.SaveAsync();
                return NoContent();
            }
            return NotFound("the trainer doesn't exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAntrenorById(int id)
        {
            var trainer = await _repository.GetByIdAsync(id);
            if (trainer != null)
            {
                _repository.Delete(trainer);
                await _repository.SaveAsync();
                return NoContent();
            }
            return NotFound("the trainer doesn't exist");
        }
        [HttpPut("email")]
        public async Task<IActionResult> ChangeEmail([FromBody] Trainer ant)
        {
            try
            {
                Trainer foundTrainer = await _repository.GetByIdAsync(ant.Id);
                if (foundTrainer != null)
                {
                    if (foundTrainer.Age == ant.Age &&
                        foundTrainer.PhoneNumber == ant.PhoneNumber &&
                        foundTrainer.Name == ant.Name &&
                        foundTrainer.Options == ant.Options)
                    {
                        bool hasSameClients = true;
                        bool hasSameGyms = true;
                        foreach (var client in ant.Clients)
                        {
                            if (!foundTrainer.Clients.Contains(client))
                                hasSameClients = false;
                        }
                        foreach (var gym in ant.TrainerGyms)
                        {
                            if (!foundTrainer.TrainerGyms.Contains(gym))
                                hasSameGyms = false;
                        }
                        if (hasSameClients == true && hasSameGyms == true)
                        {
                            _repository.Update(ant);
                            await _repository.SaveAsync();
                            return NoContent();
                        }

                    }
                    return NotFound("You can only change the email");
                }
                return NotFound("Trainer doesn't exist");
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Trainer ant)
        {
            var foundTrainer = await _repository.GetByIdAsync(ant.Id);
            if (foundTrainer != null)
            {
                if(foundTrainer.Age != ant.Age) foundTrainer.Age = ant.Age;
                if(foundTrainer.PhoneNumber!= ant.PhoneNumber) foundTrainer.PhoneNumber = ant.PhoneNumber;
                if(foundTrainer.Name!= ant.Name) foundTrainer.Name = ant.Name;
                if(foundTrainer.Email!= ant.Email) foundTrainer.Email = ant.Email;
                if(foundTrainer.Options!= ant.Options) foundTrainer.Options = ant.Options;
                _repository.Update(ant);
                await _repository.SaveAsync();
                return NoContent();
            }
            return NotFound("Trainer doesn't exist");

        }
    }
}
