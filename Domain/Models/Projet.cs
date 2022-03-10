using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Models
{
    [Table("Projets", Schema = "HR")]
    public class Projet
    {
        
        [Key]
        public Guid ID_Projet { get; set; }
        public string Nom_Projet { get; set; }
        public string Nom_Client { get; set; }
        public string Etat_projet { get; set; }
        public string Description_projet { get; set; }

        public string Debut_estime { get; set; }
        public string Fin_estime { get; set; }
        public int Debut_estimej { get; set; }
        public int Fin_estimej { get; set; }





        public Guid FK_ServiceDepartment { get; set; }
        public ServiceDepartment ServiceDepartment { get; set; }

       
        public virtual List<TimesSheet> TimesSheet { get; set; }

    }
}
