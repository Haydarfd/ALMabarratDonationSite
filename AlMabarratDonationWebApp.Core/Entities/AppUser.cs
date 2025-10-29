using Microsoft.AspNetCore.Identity;

namespace AlMabarratDonationWebApp.Core.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public string UserType { get; set; } // "Donor", "Admin", "Staff"

    // ✅ Add these fields if you’re using them in the registration
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}
