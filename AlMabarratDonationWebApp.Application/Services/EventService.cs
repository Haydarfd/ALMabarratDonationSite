//using AlMabarratDonationWebApp.Application.DTO;
//using AlMabarratDonationWebApp.Application.Interfaces.IServices;
//using AlMabarratDonationWebApp.Core.Entities;
//using AlMabarratDonationWebApp.Core.Repositories;
//using AlMabarratDonationWebApp.Entities;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AlMabarratDonationWebApp.Application.Services
//{
//    public class EventService : BaseService<EventDto, Event>, IEventService
//    {
//        private readonly IEventRepository _repository;

//        // Constructor that accepts both the repository and AutoMapper
//        public EventService(IEventRepository eventRepository, IMapper mapper)
//            : base(eventRepository, mapper)
//        {
//            _repository = eventRepository;
//        }

//        // Create method that handles custom logic for creating an Event
//        public async Task<EventDto> CreateAsync(CreateEventDto dto)
//        {
//            // Map the CreateEventDto to an Event entity
//            var entity = _mapper.Map<Event>(dto);

//            // Save the event using the repository and return the mapped DTO
//            var createdEntity = await _repository.AddAsync(entity);
//            return _mapper.Map<EventDto>(createdEntity);
//        }

//        // Update method that handles custom logic for updating an Event
//        public async Task<bool> UpdateAsync(int id, UpdateEventDto dto)
//        {
//            // Fetch the event from the repository using the provided ID
//            var entity = await _repository.GetByIdAsync(id);
//            if (entity == null) return false;

//            // Map the fields from the DTO to the existing entity
//            _mapper.Map(dto, entity);

//            // Update the entity in the repository
//            return await _repository.UpdateAsync(entity);
//        }

//        // Get all events method that uses BaseService functionality
//        public new async Task<IEnumerable<EventDto>> GetAllAsync()
//        {
//            var events = await _repository.GetAllAsync();
//            return events.Select(e => _mapper.Map<EventDto>(e));
//        }

//        // Get an event by ID method that uses BaseService functionality
//        public new async Task<EventDto> GetByIdAsync(int id)
//        {
//            var eventEntity = await _repository.GetByIdAsync(id);
//            return eventEntity == null ? null : _mapper.Map<EventDto>(eventEntity);
//        }

//        // Delete method that uses BaseService functionality
//        public new async Task<bool> DeleteAsync(int id)
//        {
//            return await _repository.DeleteAsync(id);
//        }
//    }
//}
