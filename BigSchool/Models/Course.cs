namespace _2011770131_Trần_Hân_Nhi_BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string LectureId { get; set; }

        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        

        public DateTime DateTime { get; set; }

        public int CategoryId { get; set; }

        [StringLength(250)]
        public string LectureName { get; set; }

        public virtual Category Category { get; set; }
        public List<Category> ListCategory = new List<Category>();
       
        public bool isLogin = false;
        public bool isShowGoing = false;
        public bool isShowFollow = false;
      
    }
}
