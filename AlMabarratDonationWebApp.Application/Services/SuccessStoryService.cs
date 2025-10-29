//using AlMabarratDonationWebApp.Application.DTO;
//using AlMabarratDonationWebApp.Application.Interfaces.IServices;
//using AlMabarratDonationWebApp.Core.Entities;
//using AlMabarratDonationWebApp.Core.Interfaces;
//using AlMabarratDonationWebApp.Core.Repositories;
//using AlMabarratDonationWebApp.Entities;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AlMabarratDonationWebApp.Application.Services
//{
//    public class SuccessStoryService : BaseService<SuccessStoryDto, SuccessStory>, ISuccessStoryService
//    {
//        private readonly ISuccessStoryRepository _repository;

//        // Constructor that accepts both the repository and AutoMapper
//        public SuccessStoryService(ISuccessStoryRepository repository, IMapper mapper)
//            : base(repository, mapper)
//        {
//            _repository = repository;
//        }

//        // Create method that handles custom logic for Success Stories
//        public async Task<SuccessStoryDto> CreateAsync(CreateSuccessStoryDto dto)
//        {
//            // Map the CreateSuccessStoryDto to a SuccessStory entity
//            var entity = _mapper.Map<SuccessStory>(dto);
//            entity.Date = dto.Date ?? DateTime.UtcNow; // Set date if not provided

//            // Save the success story using the repository and return the mapped DTO
//            var createdEntity = await _repository.AddAsync(entity);
//            return _mapper.Map<SuccessStoryDto>(createdEntity);
//        }

//        // Update method that handles custom logic for updating a Success Story
//        public async Task<SuccessStoryDto> UpdateAsync(int id, UpdateSuccessStoryDto dto)
//        {
//            // Fetch the success story from the repository using the provided ID
//            var entity = await _repository.GetByIdAsync(id);
//            if (entity == null) return null;

//            // Map the fields from the DTO to the existing entity
//            _mapper.Map(dto, entity);

//            // Update the entity in the repository
//            var updated = await _repository.UpdateAsync(entity);
//            return updated ? _mapper.Map<SuccessStoryDto>(entity) : null;
//        }

//        // Get all success stories method that uses BaseService functionality
//        public new async Task<IEnumerable<SuccessStoryDto>> GetAllAsync()
//        {
//            var stories = await _repository.GetAllAsync();
//            return stories.Select(s => _mapper.Map<SuccessStoryDto>(s));
//        }

//        // Get a success story by ID method that uses BaseService functionality
//        public new async Task<SuccessStoryDto> GetByIdAsync(int id)
//        {
//            var story = await _repository.GetByIdAsync(id);
//            return story == null ? null : _mapper.Map<SuccessStoryDto>(story);
//        }

//        // Delete method that uses BaseService functionality
//        public new async Task<bool> DeleteAsync(int id)
//        {
//            return await _repository.DeleteAsync(id);
//        }
//    }
//}
