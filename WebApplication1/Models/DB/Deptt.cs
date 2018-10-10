using System;
using System.Collections.Generic;

namespace WebApplication1.models.DB
{
    public partial class Deptt
    {
        public Deptt()
        {
            Emp = new HashSet<Emp>();
        }

        public int Deptid { get; set; }
        public string Name { get; set; }
        public int? Strength { get; set; }

        public ICollection<Emp> Emp { get; set; }
    }
}
