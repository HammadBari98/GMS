//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gym_Management.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class physcial_info
    {
        public int p_id { get; set; }
        public Nullable<double> T_Hieght { get; set; }
        public Nullable<double> T_Weight { get; set; }
        public Nullable<int> T_Age { get; set; }
        public int traine_id { get; set; }
    
        public virtual trainee trainee { get; set; }
    }
}
