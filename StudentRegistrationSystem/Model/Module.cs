﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Model
{
    public class Module
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public string Name { get; set; }

        public string Grade { get; set; }
        public string Code { get; set; }
    }
}
