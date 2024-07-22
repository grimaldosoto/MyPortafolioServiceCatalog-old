using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Technology
    {
        public Technology()
        {
            TechStackApps = new HashSet<TechStackApp>();
        }

        public int TechnologyId { get; set; }
        public string Name { get; set; } = null!;
        public string? Version { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TechStackApp> TechStackApps { get; set; }
    }
}
