using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.RelativeToUser
{
    public class TrimestrialInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreateInfoDate { get; set; }
        public DateTime? UpdateInfoDate { get; set; }
        public int Trimester { get; set; }
        public string ClassName { get; set; }
    }
}
