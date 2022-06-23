using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa.DTOs
{
    public class MemberPost
    {
        public int MemberID {set; get;}
        public int OrganizationID {set; get;}
        public string MemeberName {set; get;}
        public string MemeberSurname {set; get;}
        public string? MemeberNickname {set; get;}
    }
}