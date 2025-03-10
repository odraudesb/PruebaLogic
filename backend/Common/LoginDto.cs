using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Common
{
    public class LoginDto
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}
