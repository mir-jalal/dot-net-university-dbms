namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class stud_course_rel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string student { get; set; }

        [StringLength(50)]
        public string course { get; set; }

        public int? abs { get; set; }

        public int? ff { get; set; }

        public int? sdf1 { get; set; }

        public int? sdf2 { get; set; }

        public int? sdf3 { get; set; }

        public int? final { get; set; }

        public int? extra { get; set; }

        public int? re_exam { get; set; }

        public virtual Course Course1 { get; set; }

        public virtual Student Student1 { get; set; }
    }
}
