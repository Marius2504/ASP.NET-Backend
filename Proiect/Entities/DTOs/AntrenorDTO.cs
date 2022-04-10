using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.DTOs
{
    public class AntrenorDTO
    {
        public int Id { get; set; }
        public int varsta { get; set; }
        public string telefon { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Optiuni { get; set; }
        public int OmId { get; set; }
        public List<Om> Oms { get; set; }
        public List<AntrenorGym> AntrenorGyms { get; set; }

        public AntrenorDTO(Antrenor ant)
        {
            try
            {
                    this.Id = ant.Id;
                this.varsta = ant.varsta;
                this.telefon = ant.telefon;
                this.Nume = ant.Nume;
                this.Email = ant.Email;
                this.Optiuni = ant.Optiuni;
                this.OmId = ant.OmId;
                this.Oms = new List<Om>();
                this.AntrenorGyms = new List<AntrenorGym>();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
