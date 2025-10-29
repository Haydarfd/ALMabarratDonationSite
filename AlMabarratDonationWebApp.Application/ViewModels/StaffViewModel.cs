using AlMabarratDonationWebApp.Core.Entities;

namespace AlMabarratDonationWebApp.Application.ViewModels
{
    public class StaffViewModel
    {
        public int StaffID { get; set; }
        public DateOnly JoinDate { get; set; }
        public bool IsActive { get; set; }
        public bool RequiresPasswordChange { get; set; }

        // From AppUser (AspNetUser)
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

    }
}
