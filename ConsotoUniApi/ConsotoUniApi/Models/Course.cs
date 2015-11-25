using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsotoUniApi.Models
{
    public enum FinalGrade
    {
        A, B, C, D, F
    }

    public enum CompletionStatus
    {
        InProgress, Completed
    }

    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int CoursePercentage { get; set; }
        public CompletionStatus? CompletionStatus { get; set; }
        public FinalGrade? FinalGrade { get; set; }

        [JsonIgnore]
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}