using System;
using System.ComponentModel.DataAnnotations;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class UpdateStaffDto
    {
        public int StaffID { get; set; }
        public string UserId { get; set; }  // Added to match entity relationship

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(150, ErrorMessage = "Email cannot be longer than 150 characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Join Date is required.")]
        public DateTime JoinDate { get; set; }

        public bool IsActive { get; set; } = true;

        public bool RequiresPasswordChange { get; set; }

        [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
        public string Address { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "City name cannot be longer than 100 characters.")]
        public string City { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Postal Code cannot be longer than 20 characters.")]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Country name cannot be longer than 100 characters.")]
        public string Country { get; set; } = string.Empty;

        // Optional: Add password fields if you want to allow password updates
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}