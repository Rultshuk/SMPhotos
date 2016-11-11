namespace SMPhotos.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smp.User")]
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [StringLength(64)]
        public string FirstName { get; set; }

        [StringLength(64)]
        public string LastName { get; set; }

        [StringLength(64)]
        public string Location { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsUploader { get; set; }
    }
}
