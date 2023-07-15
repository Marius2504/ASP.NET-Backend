using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Options { get; set; }
        public ICollection<Client>? Clients { get; set; }
        public ICollection<TrainerGym>? TrainerGyms { get; set; }

    }
}
