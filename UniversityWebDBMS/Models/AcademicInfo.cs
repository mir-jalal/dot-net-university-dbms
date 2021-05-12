namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcademicInfos")]
    public partial class AcademicInfo
    {
        [StringLength(50)]
        public string id { get; set; }

        public int? entrance { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string advisor { get; set; }

        [StringLength(50)]
        public string dis_topic { get; set; }

        public int? exam_score { get; set; }

        public bool? state_funded { get; set; }

        public bool? presidential_scholarship { get; set; }

        [Column(TypeName = "date")]
        public DateTime? registration_date { get; set; }

        public virtual Student Student { get; set; }
    }
}
