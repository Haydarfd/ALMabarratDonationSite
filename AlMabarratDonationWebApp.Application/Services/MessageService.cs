//using AlMabarratDonationWebApp.Application.DTO;
//using AlMabarratDonationWebApp.Application.Interfaces.IServices;
//using AlMabarratDonationWebApp.Core.Entities;
//using AlMabarratDonationWebApp.Core.Interfaces.IRepository;
//using AlMabarratDonationWebApp.Core.Repositories;
//using AlMabarratDonationWebApp.Entities;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AlMabarratDonationWebApp.Application.Services
//{
//    public class MessageService : BaseService<MessageDto, Message>, IMessageService
//    {
//        private readonly IMessageRepository _repository;
//        private readonly IMapper _mapper;

//        public MessageService(IMessageRepository repository, IMapper mapper)
//            : base(repository, mapper)
//        {
//            _repository = repository;
//            _mapper = mapper;
//        }

//        public async Task<MessageDto> CreateAsync(CreateMessageDto dto)
//        {
//            var entity = _mapper.Map<Message>(dto);

//            entity.FullName ??= "Anonymous";
//            entity.Subject ??= "No Subject";

//            if (string.IsNullOrEmpty(entity.Message1))
//            {
//                throw new ArgumentNullException(nameof(dto.Message1));
//            }

//            entity.DateReceived ??= DateTime.UtcNow;
//            entity.Status ??= "New";

//            var createdEntity = await _repository.AddAsync(entity);
//            return _mapper.Map<MessageDto>(createdEntity);
//        }

//        public async Task<MessageDto> UpdateAsync(int id, UpdateMessageDto dto)
//        {
//            var entity = await _repository.GetByIdAsync(id);
//            if (entity == null) return null;

//            _mapper.Map(dto, entity);

//            var updated = await _repository.UpdateAsync(entity);
//            return updated ? _mapper.Map<MessageDto>(entity) : null;
//        }

//        public new async Task<IEnumerable<MessageDto>> GetAllAsync()
//        {
//            var messages = await _repository.GetAllAsync();
//            return messages.Select(m => _mapper.Map<MessageDto>(m));
//        }

//        public new async Task<MessageDto> GetByIdAsync(int id)
//        {
//            var message = await _repository.GetByIdAsync(id);
//            return message == null ? null : _mapper.Map<MessageDto>(message);
//        }

//        public new async Task<bool> DeleteAsync(int id)
//        {
//            return await _repository.DeleteAsync(id);
//        }
//    }
//}
