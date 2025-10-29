//using AlMabarratDonationWebApp.Core.Entities;
//using AlMabarratDonationWebApp.Core.Interfaces;
//using AlMabarratDonationWebApp.Core.Interfaces.IRepository;
//using AlMabarratDonationWebApp.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AlMabarratDonationWebApp.Infrastructure.Repositories
//{
//    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
//    {
//        private readonly AppDbContext _context;

//        public PaymentRepository(AppDbContext context) : base(context)
//        {
//            _context = context;
//        }

//        // Custom logic: Get all payments, ordered by PaymentDate
//        public override async Task<IEnumerable<Payment>> GetAllAsync()
//        {
//            return await _context.Payments
//                .OrderBy(p => p.PaymentDate) // Or any other sorting logic
//                .ToListAsync();
//        }

//        // Custom logic: Get payment by ID
//        public override async Task<Payment> GetByIdAsync(int id)
//        {
//            return await _context.Payments
//                .FirstOrDefaultAsync(p => p.PaymentId == id); // Ensure this is the correct field for the primary key
//        }
//    }
//}
