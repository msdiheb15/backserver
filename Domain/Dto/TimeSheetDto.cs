using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class TimeSheetDto
    {
        public Guid ID_TimesSheet { get; set; }
        public string Heure_debut { get; set; }

        public string Heure_fin { get; set; }

        public string Description { get; set; }

        public string CreatedNow { get; set; }
        public Boolean Validation { get; set; }
      

    }
}
