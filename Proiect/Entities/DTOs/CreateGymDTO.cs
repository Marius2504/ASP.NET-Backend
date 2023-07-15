using System.Collections.Generic;

namespace Proiect.Entities.DTOs
{
    public class CreateGymDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Options { get; set; }
        public Address Address { get; set; }
    }
}
