namespace _2011770131_Trần_Hân_Nhi_BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendance")]
    public partial class Attendance
    {
        public Course Course { get; set; }

        [Key]
        [Column(Order =1)]
        public int CourseId { get;set; }

        [Key]
        [Column(Order =2)]
        public string Attendee { get; set; }    
    }
}