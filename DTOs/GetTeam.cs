using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa.DTOs
{
    public class GetTeam
    {
        public int TeamID { get; set; }
        public string TeamName{get;set;}
        public string TeamDescription{get;set;}
        public string OrganizationName{get;set;}
        public List<Members> Member{get;set;}

    }
    public class Members
    {
        public int MemberID { get; set; }
        public int OrganizationID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickName { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}