using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.businesslogic;
using System.Web;
using afdsl.DataLayer.Entity_FrameWork;

namespace afdsl.BusinessLayer.afdsl.Member
{
    public class afdsl_Member
    {
        public string member_UserName { get; set; }
        public string member_EmailAddress { get; set; }
        public int member_id { get; set; }
        public bool member_NewsLetterSignUp { get; set; }
        public string member_Password { get; set; }
        public string member_MembersType { get; set; }
        public string member_MembersGroup { get; set; }
        public Guid member_MembersGuid { get; set; }
    }
}
