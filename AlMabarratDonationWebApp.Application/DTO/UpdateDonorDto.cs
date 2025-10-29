using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class UpdateDonorDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; }
    }

}
