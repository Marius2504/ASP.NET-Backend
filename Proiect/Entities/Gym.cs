using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Gym
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string Name { get; set; }
        public string Ratings { get; set; }
        public string Options { get; set; }

        //public int AddressId { get; set; }
        //[ForeignKey("AddressId")]
        public Address? Address { get; set; }
        public ICollection<TrainerGym>? TrainerGyms { get; set; }
        //public ICollection<Client>? Clients { get; set; }
        
    }
}
