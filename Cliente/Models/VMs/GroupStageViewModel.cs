﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Models.VMs
{
    public class GroupStageViewModel
    {
        public string group { get; set; }
        public List<NationalTeamViewModel> nationalTeams { get; set; }
    }
}
