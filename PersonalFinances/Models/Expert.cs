using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class Expert
    {
        public Expert()
        {
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public decimal ExpretId { get; set; }
        public string ExpertType { get; set; }
        public string ExpertName { get; set; }
        public string ExpertSurname { get; set; }
        public string ExpertLastname { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
