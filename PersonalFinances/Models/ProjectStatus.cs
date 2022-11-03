using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class ProjectStatus
    {
        public ProjectStatus()
        {
            Projects = new HashSet<Project>();
        }

        public decimal PstatusId { get; set; }
        public string PstatusName { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
