using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class StaffDto
    {
        public int StaffId { get; set; }

        // From AppUser
        public string UserID { get; set; } = null!;

        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;

        // From Staff
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }

    }
}
