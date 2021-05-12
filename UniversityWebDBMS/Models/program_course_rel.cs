namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class program_course_rel
    {
        public int id { get; set; }

        [StringLength(50)]
        public string program { get; set; }

        [StringLength(50)]
        public string course { get; set; }

        public virtual Course Course1 { get; set; }

        public virtual Program Program1 { get; set; }
    }
}
