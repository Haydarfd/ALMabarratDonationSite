using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AutoMapper;

public class OrphanService : IOrphanService
{
    private readonly IOrphanRepository _repo;
    private readonly IMapper _mapper;
    private readonly INationalityRepository _nationalityRepo;

    public OrphanService(IOrphanRepository repo, IMapper mapper, INationalityRepository nationalityRepo)
    {
        _repo = repo;
        _mapper = mapper;
        _nationalityRepo = nationalityRepo;

    }

    public async Task<List<string>> GetAllNationalityNamesAsync()
    {
        var nationalities = await _nationalityRepo.GetAllAsync();
        return nationalities
            .Where(n => !string.IsNullOrWhiteSpace(n.Name))
            .Select(n => n.Name)
            .Distinct()
            .OrderBy(n => n)
            .ToList();
    }
    public async Task<OrphanDto> CreateAsync(CreateOrphanDto dto)
    {
        var orphan = _mapper.Map<Orphan>(dto);
        var created = await _repo.AddAsync(orphan);
        return _mapper.Map<OrphanDto>(created);
    }

    public async Task<OrphanDto> UpdateAsync(UpdateOrphanDto dto)
    {
        var orphan = await _repo.GetByIdAsync(dto.OrphanID);
        if (orphan == null || orphan.IsDeleted)
        {
            throw new Exception("Orphan not found");
        }

        _mapper.Map(dto, orphan);
        await _repo.UpdateAsync(orphan);
        return _mapper.Map<OrphanDto>(orphan);
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var orphan = await _repo.GetByIdAsync(id);
        if (orphan == null || orphan.IsDeleted)
            return false;

        return await _repo.DeleteAsync(orphan);
    }

    public async Task<OrphanDto> GetByIdAsync(int id)
    {
        var orphan = await _repo.GetByIdAsync(id);
        if (orphan == null || orphan.IsDeleted)
            throw new Exception("Orphan not found");

        return _mapper.Map<OrphanDto>(orphan);
    }

    public async Task<List<OrphanDto>> GetAllAsync()
    {
        // Directly fetch all without filtering for testing
        var orphans = await _repo.GetAllAsync();
        return _mapper.Map<List<OrphanDto>>(orphans);
    }


}
