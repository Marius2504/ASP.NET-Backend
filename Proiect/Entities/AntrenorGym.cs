using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class AntrenorGym
    {
        public int AntrenorId { get; set; }
        public int GymId { get; set; }
        public Antrenor Antrenors{ get; set; }
        public Gym Gyms { get; set; }

    }
}
