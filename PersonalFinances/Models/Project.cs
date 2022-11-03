using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public decimal ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectClient { get; set; }
        public DateTime ProjectBegin { get; set; }
        public DateTime ProjectEnd { get; set; }
        public decimal ProjectStatus { get; set; }
        public decimal? ProjectPayPerHour { get; set; }

        public virtual ProjectStatus ProjectStatusNavigation { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
