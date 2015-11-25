using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsotoUniApi.Models
{
    public enum WorkType
    {
        Assignment, Test
    }

    public enum Grade
    {
        A, B, C, D, F
    }

    public class CourseWork
    {
        public int CourseWorkID { get; set; }
        public string Title { get; set; }
        public WorkType? WorkType { get; set; }
        public DateTime DueDate { get; set; }
        public Grade? Grade { get; set; }

        [JsonIgnore]
        public virtual ICollection<Correlation> Correlations { get; set; }
    }
}