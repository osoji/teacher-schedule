using System.ComponentModel.DataAnnotations;

namespace RankenSchedule.UI.Models.DomainModels
{
    public class Teacher
    {
        public Teacher() => Classes = new HashSet<Class>(); //Constructor initializes collection.
                                                            //Note HashSet can not store duplicate key or like list
        public int TeacherId { get; set; } //Primary Key

        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage ="First name may not exceed 100 characters.")]
        [Required(ErrorMessage ="Please enter a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name ="Last Name")]
        [StringLength(100, ErrorMessage ="Last name may not exceed 100 characters.")]
        [Required(ErrorMessage ="Please enter a last name")]
        public string LastName { get; set; } = String.Empty;

        // Read-only display property
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Class> Classes { get; set; } //Navigation property
    }
}
