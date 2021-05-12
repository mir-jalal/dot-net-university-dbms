namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            stud_course_rel = new HashSet<stud_course_rel>();
            stud_prog_rel = new HashSet<stud_prog_rel>();
        }

        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        [StringLength(50)]
        public string patronymic { get; set; }

        [StringLength(50)]
        public string program { get; set; }

        public virtual AcademicInfo AcademicInfo { get; set; }

        public virtual Program Program1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stud_course_rel> stud_course_rel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stud_prog_rel> stud_prog_rel { get; set; }

        public virtual User User { get; set; }
    }
}
