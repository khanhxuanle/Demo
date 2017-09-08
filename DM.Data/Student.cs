namespace DM.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int id { get; set; }

        public int ClassId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        public int StudentAge { get; set; }

        [StringLength(500)]
        public string StudentAddress { get; set; }

        [StringLength(50)]
        public string StudentSex { get; set; }

        public virtual Class Class { get; set; }
    }
}
