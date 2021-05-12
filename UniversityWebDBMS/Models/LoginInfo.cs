namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginInfo")]
    public partial class LoginInfo
    {
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string sessionid { get; set; }

        [StringLength(200)]
        public string browser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? lastLogin { get; set; }

        public virtual LoginCredential LoginCredential { get; set; }
    }
}
