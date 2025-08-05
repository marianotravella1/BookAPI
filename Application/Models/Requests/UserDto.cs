using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class UserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
