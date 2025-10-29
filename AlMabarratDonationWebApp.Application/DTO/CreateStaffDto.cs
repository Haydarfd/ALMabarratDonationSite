using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AlMabarratDonationWebApp.Application.Interfaces;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class CreateStaffDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(150, ErrorMessage = "Email cannot be longer than 150 characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Temporary password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Temporary password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Temporary password must contain at least one letter and one number.")]
        public string TemporaryPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full Name can only contain letters and spaces.")]
        public string FullName { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Join Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [CustomDateValidation(ErrorMessage = "Join Date must not be in the future.")]
        public DateTime JoinDate { get; set; }

        public bool IsActive { get; set; } = true;

        [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
        public string Address { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "City name cannot be longer than 100 characters.")]
        public string City { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Postal Code cannot be longer than 20 characters.")]
        [RegularExpression(@"^[A-Za-z0-9\s\-]+$", ErrorMessage = "Postal Code can only contain letters, numbers, spaces, and hyphens.")]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Country name cannot be longer than 100 characters.")]
        public string Country { get; set; } = string.Empty;
    }

    // Custom validation for join date
    public class CustomDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime <= DateTime.Now;
            }
            return true; // return true if the value is null
        }
    }
}