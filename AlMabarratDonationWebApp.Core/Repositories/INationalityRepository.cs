using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Core.Repositories
{
    public interface INationalityRepository
    {
        Task<List<Nationality>> GetAllAsync();
    }

}
