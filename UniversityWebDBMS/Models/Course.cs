namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            program_course_rel = new HashSet<program_course_rel>();
            stud_course_rel = new HashSet<stud_course_rel>();
        }

        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? credit { get; set; }

        public int? hours { get; set; }

        public int? lab { get; set; }

        public int? lec { get; set; }

        public int? exe { get; set; }

        public int? semester { get; set; }

        [StringLength(50)]
        public string program { get; set; }

        public virtual Program Program1 { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<program_course_rel> program_course_rel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stud_course_rel> stud_course_rel { get; set; }
    }
}
