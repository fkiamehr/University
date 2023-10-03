using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.DataLayer.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }

        [Display(Name = " نام خانوادگی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(30, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Family { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime? RegisterDate { get; set; }

        public int LevelId { get; set; }

        #region Relations
        [ForeignKey("LevelId")]
        public StudentLevel? StudentLevel { get; set; }

        #endregion

    }
}
