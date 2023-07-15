using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        //Relationships
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer? Trainer { get; set; }

        //gym
        //public int GymId { get; set; }
       // [ForeignKey("GymId")]
      //  public Gym Gym { get; set; }

    }
}
