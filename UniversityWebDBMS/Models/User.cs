namespace UniversityWebDBMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        public virtual LoginCredential LoginCredential { get; set; }

        public virtual Student Student { get; set; }
    }
}
