using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Domain.Models
{

    [Table("TimesSheets", Schema = "HR")]
    public class TimesSheet
    {
     
        [Key]
      
        public Guid ID_TimesSheet { get; set; }

        public string Heure_debut { get; set; }

        public string Heure_fin { get; set; }

        public string Description { get; set; }

        public Boolean Validation { get; set; }

        public string CreatedNow { get; set; }




        public Guid FK_Person { get; set; }
        public Person Person { get; set; }

        public Guid FK_Projet { get; set; }
        public Projet Projet { get; set; }

        public Guid FK_Tache { get; set; }
        public Tache Tache { get; set; }


    }
}
