using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class UpdateMessageDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Subject { get; set; }
        public string? Message1 { get; set; }
        public DateTime? DateReceived { get; set; }
        public string? Status { get; set; }
    }
}
