using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Authentication
{
    public class RegisterDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
