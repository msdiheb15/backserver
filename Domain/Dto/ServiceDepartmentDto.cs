using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Dto
{
    public class ServiceDepartmentDto
    {
        public Guid ID_ServiceDepartment { get; set; }
        public string libelle_service { get; set; }

    }
}
