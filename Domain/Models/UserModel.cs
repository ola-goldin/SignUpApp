using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [Required(ErrorMessage = "The {0} field is required.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numeric characters.")]
        [StringLength(9, MinimumLength = 6, ErrorMessage = "The {0} field must be between {2} and {1} characters.")]
        public required string IdentityNumber { get; set; }



        [Required(ErrorMessage = "The {0} field is required.")]
        [RegularExpression("^[A-Za-z\\s' -]*$", ErrorMessage = "Please enter letters, space, hyphen, apostrophe.")]
        [DefaultValue("Jane")] // Default value for Swagger
        public required string FirstName { get; set; }



        [Required(ErrorMessage = "The {0} field is required.")]
        [RegularExpression("^[A-Za-z\\s' -]*$", ErrorMessage = "Please enter letters, space, hyphen, apostrophe.")]
        [DefaultValue("Doe")] // Default value for Swagger
        public required string LastName { get; set; }


        [EmailAddress]
        public string? Email { get; set; }


        [Required(ErrorMessage = "The {0} field is required.")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public required DateTime DateOfBirth { get; set; }



        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender value.")]
        public Gender? Gender { get; set; }


        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter only numeric characters.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "The {0} field must be between {2} and {1} characters.")]
        public string? PhoneNumber { get; set; }
    }
}
