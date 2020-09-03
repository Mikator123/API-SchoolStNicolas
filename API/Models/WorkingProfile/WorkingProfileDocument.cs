using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.WorkingProfile
{
    public class WorkingProfileDocument
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int SchoolYear { get; set; }
        public int Trimester { get; set; }
        public int SchoolYearCategoryId { get; set; }
    }
}
