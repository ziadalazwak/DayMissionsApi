﻿
using DayMissions.Domain.Entities;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.Domain.Entities { 
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TaskDefination>? Tasks;
    }
}
