namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoginCredential
    {
        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string role { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public virtual LoginInfo LoginInfo { get; set; }

        public virtual User User { get; set; }
    }
}
