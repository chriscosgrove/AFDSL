//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace afdsl.DataLayer.Entity_FrameWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class cmsMember
    {
        public int nodeId { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public Nullable<int> FK_User_Table { get; set; }
    
        public virtual cmsMember cmsMember1 { get; set; }
        public virtual afdsl_Custom_User_Table afdsl_Custom_User_Table { get; set; }
    }
}