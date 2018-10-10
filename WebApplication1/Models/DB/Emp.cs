using System;
using System.Collections.Generic;

namespace WebApplication1.models.DB
{
    public partial class Emp
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        public int? Deptid { get; set; }

        public Deptt Dept { get; set; }
    }
}
