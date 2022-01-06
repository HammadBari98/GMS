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
    
    public partial class trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainer()
        {
            this.equipments = new HashSet<equipment>();
            this.student_trainer = new HashSet<student_trainer>();
        }
    
        public int trainer_id { get; set; }
        public string trainer_name { get; set; }
        public string trainer_speciality { get; set; }
        public Nullable<int> trainer_salary { get; set; }
        public Nullable<int> for_weight { get; set; }
        public string Gender { get; set; }
        public string trainer_password { get; set; }
        public Nullable<int> trainee_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<equipment> equipments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student_trainer> student_trainer { get; set; }
        public virtual trainee trainee { get; set; }
    }
}
