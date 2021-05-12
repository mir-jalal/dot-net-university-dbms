namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class stud_prog_rel
    {
        public int id { get; set; }

        [StringLength(50)]
        public string student { get; set; }

        [StringLength(50)]
        public string program { get; set; }

        [StringLength(5)]
        public string gpa { get; set; }

        public virtual Program Program1 { get; set; }

        public virtual Student Student1 { get; set; }
    }
}
