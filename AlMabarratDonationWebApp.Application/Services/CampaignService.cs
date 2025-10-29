using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _repository;
        private readonly IMapper _mapper;

        public CampaignService(ICampaignRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CampaignDto> CreateAsync(CreateCampaignDto dto)
        {
            var entity = _mapper.Map<Campaign>(dto);
            entity.CurrentAmount = 0;
            var createdEntity = await _repository.AddAsync(entity);
            return _mapper.Map<CampaignDto>(createdEntity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateCampaignDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }


        public async Task<IEnumerable<CampaignDto>> GetAllAsync()
        {
            var campaigns = await _repository.GetAllAsync();
            return campaigns.Select(c => _mapper.Map<CampaignDto>(c));
        }

        public async Task<CampaignDto> GetByIdAsync(int id)
        {
            var campaign = await _repository.GetByIdAsync(id);
            return campaign == null ? null : _mapper.Map<CampaignDto>(campaign);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            return await _repository.DeleteAsync(entity);
        }

        public Task<CampaignDto> CreateAsync(CampaignDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, CampaignDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
