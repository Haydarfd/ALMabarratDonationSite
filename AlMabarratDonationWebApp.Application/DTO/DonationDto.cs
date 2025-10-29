using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class DonationDto
    {
        public int DonationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string DonationTypeName { get; set; } = string.Empty;
    }
}
