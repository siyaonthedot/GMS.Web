//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GMS.Web.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberAttendency
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> TimeIn { get; set; }
        public Nullable<System.DateTime> TimeOut { get; set; }
    
        public virtual MemberAttendency MemberAttendency1 { get; set; }
        public virtual MemberAttendency MemberAttendency2 { get; set; }
    }
}
