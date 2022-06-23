using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa.Entities.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }
        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}