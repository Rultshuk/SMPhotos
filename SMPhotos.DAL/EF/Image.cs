namespace SMPhotos.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("smp.Image")]
    public partial class Image
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(64)]
        public string Description { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
