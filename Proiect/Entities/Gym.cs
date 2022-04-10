using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class Gym
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string Nume { get; set; }
        public string Recenzii { get; set; }
        public string Optiuni { get; set; }
        public Adresa Adresas { get; set; }
        public ICollection<AntrenorGym> AntrenorGyms { get; set; }

    }
}
