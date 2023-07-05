using System.ComponentModel.DataAnnotations;

namespace DanceAcademyCrudAdo.Models
{
    public class DanceUserModel
    {
        [Display(Name = "Student ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Student Name")]
        public string StuName { get; set; }
        [Required(ErrorMessage = "Age Required")]
        [Range(6, 15, ErrorMessage = "Age must be between 6 to 15")]
        [Display(Name = "Student Age")]
        public int StuAge { get; set; }
        [Required(ErrorMessage = "Parent Name Required")]
        [Display(Name = "Parent Name")]
        public string StuParentName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        [Display(Name = "Student Email")]
        public string StuEmail { get; set; }
        [Required(ErrorMessage = "Mobile Required")]
        [Display(Name = "Student Mobile")]
        public string StuMobile { get; set; }
    }
}