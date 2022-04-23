using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalsMP_Rivadenera_Cajoles_Cibak.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string id { get; set; }
        [Required(ErrorMessage = "Role Name is required.")]
        public string RoleName { get; set; }

        public List <string> Users{get;set;}
    }
}
