﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManagement.Model
{
public class User
    {
            public int UserId { get; set; }
            public string Username { get; set; } = "";
            public string PasswordHash { get; set; } = "";
            public string UserRole { get; set; } = "";
        }
    }

