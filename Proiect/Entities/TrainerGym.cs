using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class TrainerGym
    {
       // public int Id { get; set; }
        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public Trainer? Trainer { get; set; }
        
        public int GymId { get; set; }
        [ForeignKey("GymId")]
        public Gym? Gym { get; set; }
        
    }
}
