using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<TrainerGym> TrainerGyms { get; set; }

        public  TrainerDTO(Trainer ant)
        {
           this.Id = ant.Id;
           this.Name = ant.Name;
           this.Clients = new List<Client>();
           this.TrainerGyms = new List<TrainerGym>();
        }
    }
}
