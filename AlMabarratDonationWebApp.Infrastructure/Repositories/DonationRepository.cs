using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Data;
using AlMabarratDonationWebApp.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Infrastructure.Repositories
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        public DonationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
