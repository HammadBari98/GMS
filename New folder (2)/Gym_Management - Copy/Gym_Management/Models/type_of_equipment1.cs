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
    
    public partial class type_of_equipment1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public type_of_equipment1()
        {
            this.physcial_details = new HashSet<physcial_details>();
        }
    
        public int to_eq_id { get; set; }
        public Nullable<int> trainee_id { get; set; }
        public Nullable<int> t_e_id { get; set; }
    
        public virtual trainee trainee { get; set; }
        public virtual type_of_equipment type_of_equipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<physcial_details> physcial_details { get; set; }
    }
}