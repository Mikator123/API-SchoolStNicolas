using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DistancialTest
{
    public class WorkingProfileQuestion
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Question { get; set; }
        public string Correction { get; set; }
        public string Explanation { get; set; }
        public string FirstHint { get; set; }
        public string SecondHint { get; set; }
        public int? CategoryId { get; set; }
        public int SchoolYear { get; set; }
        public int Trimester { get; set; }
        public int SchoolYearCategoryId { get; set; }
    }
}
