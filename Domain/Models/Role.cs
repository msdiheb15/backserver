using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("Roles", Schema = "HR")]
    public class Role
    {

       
    
        [Key]
        
        public Guid ID_Role { get; set; }
        public string Libelle_Role { get; set; }

        public virtual List<Person> Persons { get; set; }






    }
    }
