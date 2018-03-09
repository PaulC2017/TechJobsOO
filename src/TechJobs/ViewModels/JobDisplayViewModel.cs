using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobs.Models;
using TechJobs.Data;

namespace TechJobs.ViewModels
{
    public class JobDisplayViewModel
    {
        public string Name { get; set; }
        public Employer Employer { get; set; }
        public Location Location { get; set; }
        public CoreCompetency CoreCompetency { get; set; }
        public PositionType PositionType { get; set; }


    }
}
