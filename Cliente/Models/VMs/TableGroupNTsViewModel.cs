using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Models.VMs
{
    public class TableGroupNTsViewModel
    {
        public string country { get; set; }
        public int pts { get; set; }
        public int goalsScored { get; set; }
        public int goalsAgainst { get; set; }
        public int yellowCards { get; set; }
        public int redCards { get; set; }
        public int directRedCards { get; set; }
    }
}
