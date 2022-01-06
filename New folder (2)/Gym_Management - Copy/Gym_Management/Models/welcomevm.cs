using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_Management.Models
{
    public class welcomevm
    {
        public List<trainee> trainees { get; set; }
        public List<trainer> trainers { get; set; }
        public List<equipment> equipment { get; set; }
        public List<chart> charts { get; set; }
        public List<Gym_Branch_1> branch { get; set; }
    }
}