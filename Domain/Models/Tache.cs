using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("Taches", Schema = "HR")]

    public class Tache
    {
        [Key]
        public Guid ID_Taches { get; set; }
        public string Nom_tache { get; set; }
        public string Discription { get; set; }



        public Guid FK_ServiceDepartment { get; set; }
        public ServiceDepartment ServiceDepartment { get; set; }
        public virtual List<TimesSheet> TimesSheet { get; set; }



    }

}