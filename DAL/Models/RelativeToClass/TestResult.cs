using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.RelativeToClass
{
    public class TestResult
    {
        public int Id { get; set; }
        public double Result { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int? ClassId { get; set; }
        public int StudentId { get; set; }
    }
}
