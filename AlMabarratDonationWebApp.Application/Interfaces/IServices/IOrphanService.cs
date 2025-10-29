using AlMabarratDonationWebApp.Application.DTO;

public interface IOrphanService
{
    Task<OrphanDto> CreateAsync(CreateOrphanDto dto);
    Task<OrphanDto> UpdateAsync(UpdateOrphanDto dto);
    Task<bool> DeleteAsync(int id);
    Task<OrphanDto> GetByIdAsync(int id);
    Task<List<OrphanDto>> GetAllAsync();
    Task<List<string>> GetAllNationalityNamesAsync();

}
