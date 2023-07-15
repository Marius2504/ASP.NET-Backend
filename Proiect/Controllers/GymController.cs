using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Entities.DTOs;
using Proiect.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGymRepository _repository;
        public GymController(IGymRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllGyms() 
        {
            var list =  _repository.GetAll();
            List<Gym> listGym = new();

            foreach(var gym in list)
                listGym.Add(gym);

            return Ok(listGym);
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetGymById(int id) 
        {
            var gym = await _repository.GetByIdAsync(id);

            if(gym !=null)
                return Ok(gym);
            return NotFound("No gym found with id:" + id);
        }
        [HttpGet("/name/{name}")]
        public async Task<IActionResult> GetGymByName(string name)
        {
            var gym = await _repository.GetGymByName(name);
            if (gym != null)
                return Ok(gym);
            return NotFound("No gym found with name:" + name);
        }

        [HttpGet("/address")]
        public async Task<IActionResult> GetGymsInCity([FromBody] Address address)
        {
            /*
            var list =await _repository.GetAll()
                             .Include(gym => gym.Address)
                             .Where(gym =>gym.Address.City == address.City)
                             .ToListAsync();
            
            if(list.Count > 0)
                return Ok(list);
            */
            return NotFound("No gyms found in this area");
        }
        [HttpPost]
        public async Task<IActionResult> AddGym([FromBody]CreateGymDTO gym)
        {
            Gym newGym = new Gym();
            newGym.Id = gym.Id;
            newGym.Name= gym.Name;
            newGym.Address=gym.Address;
            newGym.Rating = 0;
            newGym.Options= gym.Options;
        
            _repository.Create(newGym);
            await _repository.SaveAsync();
            return Ok(gym);
        }
        [HttpPut("/update")]
        public async Task<IActionResult> ChangeGym([FromBody]Gym gym)
        {
            _repository.Update(gym);
            await _repository.SaveAsync();
            return Ok(gym);
        }
        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            var gym = await _repository.GetByIdAsync(id);
            if (gym != null)
            {
                _repository.Delete(gym);
                await _repository.SaveAsync();
            }
            else
                return NotFound();

            return NoContent();
        }
    }
}
