using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class LoginResponse
    {

        public bool isSuccess { get; set; }
        public string token { get; set; }
        public int usuarioId { get; set; }
    }
}
