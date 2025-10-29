using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NationalityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Nationality>>> GetAllAsync()
        {
            var nationalities = await _context.Nationalities
                .OrderBy(n => n.Name)
                .ToListAsync();

            return Ok(nationalities);
        }
    }
}
