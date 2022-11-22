using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Models.VMs
{
    public class GroupStageViewModel
    {
        public int id { get; set; }
        [Display(Name = "Grupo")]
        public string group { get; set; }
        public List<NationalTeamViewModel> nationalTeams { get; set; }
    }
}
