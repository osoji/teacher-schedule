using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RankenSchedule.UI.Models.DomainModels
{
    public class Class
    {
        public int ClassId { get; set; }

        [StringLength(200, ErrorMessage ="Title may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a calss title.")]
        public string Title { get; set; } = string.Empty;

        [Range(100, 500, ErrorMessage = "Class number must be between 100 and 500.")]
        [Required(ErrorMessage = "Please enter a calss number.")]
        public int? Number { get; set; }

        [Display(Name ="Time")]
        [RegularExpression("^[0-9]*$", ErrorMessage ="Please enter number only for class time.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage ="Class time must be 4 characters long.")]
        [Required(ErrorMessage ="Pleae enter a class time (in military time format).")]
        public string MilitaryTime { get; set; } = string.Empty;

        //Read-only property for the slug
        public string slug => Title.Replace(' ','-').ToLower()+ '-' + Number?.ToString();

        public int TeacherId { get; set; } //Foregn key property
        [ValidateNever]
        public Teacher Teacher { get; set; } = null!; //Navigation property

        public int DayId { get; set; } //Foregn key property
        [ValidateNever]
        public Day Day { get; set; } = null!; //Navigation property
    }
}
