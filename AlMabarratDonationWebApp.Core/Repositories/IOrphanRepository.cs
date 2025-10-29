using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories.Base;

public interface IOrphanRepository : IRepository<Orphan>
{
    Task<List<Orphan>> GetSponsoredOrphansAsync();
    Task<List<Orphan>> GetUnsponsoredOrphansAsync();
    Task<List<Orphan>> GetOrphansByAgeRangeAsync(int minAge, int maxAge);
    Task<List<Orphan>> GetOrphansByDonorIdAsync(int donorId);
    Task<Donor> GetSponsorByOrphanIdAsync(int orphanId);
    void AssignSponsor(int orphanId, int donorId);
    void RemoveSponsor(int orphanId);
}