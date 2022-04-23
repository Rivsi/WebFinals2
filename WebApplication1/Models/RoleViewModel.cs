using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalsMP_Rivadenera_Cajoles_Cibak.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Role Name field is required.")]
        public string RoleName { get; set; }
    }
}
