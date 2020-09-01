﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class SchoolEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int NbrOfPersons { get; set; }
    }
}
