using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class ProjetDto
    {
        public Guid ID_Projet { get; set; }
        public string Nom_Projet { get; set; }
        public string Nom_Client { get; set; }
        public string Etat_projet { get; set; }
        public string Description_projet { get; set; }
        
        public DateTime Debut_estime { get; set; }
        public DateTime Fin_estime { get; set; }
        public DateTime Debut_estimej { get; set; }
        public DateTime Fin_estimej { get; set; }




    }
}
