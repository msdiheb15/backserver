using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Domain.Models
{
    [Table("ServiceDepartments", Schema = "HR")]
    public class ServiceDepartment
    {

      
        
        [Key]
        public Guid ID_ServiceDepartment { get; set; }
        public string libelle_service { get; set; }

        public virtual List<Projet> Projet { get; set; }
        public virtual List<Person> persons { get; set; }
        public virtual List<Tache> Tache { get; set; }
    }
}
