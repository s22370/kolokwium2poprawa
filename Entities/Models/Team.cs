using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa.Entities.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }

        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

        public virtual  Organization Organization {get;set;}
        public virtual ICollection<File> File { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
    }
}