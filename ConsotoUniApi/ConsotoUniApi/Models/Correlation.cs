using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsotoUniApi.Models
{
    public class Correlation
    {
        public int CorrelationID { get; set; }
        public int CourseID { get; set; }
        public int CourseWorkID { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
        public virtual CourseWork CourseWork { get; set; }
    }
}