using Domain.DAL;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Reflection;

namespace Domain.BLL
{
    public class ModelsConverter
    {
       
        public UserModel ConvertToModel(UserDTO user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IdentityNumber = user.IdentityNumber,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = ConvertToGender(user.Gender)
            };

        }

        public UserDTO ConvertToDTO(UserModel user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IdentityNumber = user.IdentityNumber,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender.HasValue ? user.Gender.ToString() : null
            };

        }


        private Gender? ConvertToGender(string? userGender)
        {
            if (Enum.TryParse(typeof(Gender), userGender, true, out var gender))
            {
                return (Gender)gender;
            }

            return null;
        }

    }
}
