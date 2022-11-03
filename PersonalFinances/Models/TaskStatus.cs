using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public decimal StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
