﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Dtos.Authentication
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }    
        public string ConfirmPassword { get; set; } 
    }
}
