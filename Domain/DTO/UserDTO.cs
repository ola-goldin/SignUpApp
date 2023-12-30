using Domain.Models;
using System.ComponentModel;

namespace Domain.DTO
{
    public class UserDTO: UserModel
    {
        public UserDTO(){ }

        [DefaultValue("Female")]  // Default value for Swagger
        public new string? Gender { get; set; }
        public UserDTO(UserModel user)
        {
            Id = user.Id;
            IdentityNumber = user.IdentityNumber;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            DateOfBirth = user.DateOfBirth;
            Gender = user.Gender?.ToString() ;
            PhoneNumber = user.PhoneNumber;
        }
    }
}
