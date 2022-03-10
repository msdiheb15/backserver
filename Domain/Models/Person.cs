using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Persons", Schema = "HR")]
    public class Person
    {
        [Key]
        public Guid ID_person { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cin { get; set; }
        public string Adresse { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public bool Activation { get; set; }

        public Guid FK_ServiceDepartment { get; set; }
        public ServiceDepartment ServiceDepartment { get; set; }

        public Guid FK_Role { get; set; }

        public Role Role { get; set; }

        public virtual List<TimesSheet> TimesSheet { get; set; }



    }
}
