using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class NationalityRepository : INationalityRepository
{
    private readonly AppDbContext _context;

    public NationalityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Nationality>> GetAllAsync()
    {
        return await _context.Nationalities
            .Where(n => !string.IsNullOrWhiteSpace(n.Name))
            .ToListAsync();
    }
}
