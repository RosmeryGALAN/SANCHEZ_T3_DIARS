using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T3_Rosmery.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
