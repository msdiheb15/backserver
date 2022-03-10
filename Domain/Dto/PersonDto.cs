using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    
    public class PersonDto
    {
        public Guid ID_person { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Cin { get; set; }
        public string Adresse { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Activation { get; set; }

        

    }
}
