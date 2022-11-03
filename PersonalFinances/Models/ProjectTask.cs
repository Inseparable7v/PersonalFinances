using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class ProjectTask
    {
        public decimal TaskId { get; set; }
        public decimal ProjectId { get; set; }
        public decimal ExpretId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TasDeliverables { get; set; }
        public DateTime TaskBegin { get; set; }
        public DateTime TaskEnd { get; set; }
        public string TaskPriority { get; set; }
        public decimal TaskStatus { get; set; }
        public decimal? TaskReady { get; set; }
        public decimal? TaskHours { get; set; }

        public virtual Expert Expret { get; set; }
        public virtual Project Project { get; set; }
        public virtual TaskStatus TaskStatusNavigation { get; set; }
    }
}
