
//using AlMabarratDonationWebApp.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore.SqlServer;

//using System.IO;

//namespace AlMabarratDonationWebApp.Infrastructure.Data
//{
//    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContextt>
//    {
//        public AppDbContextt CreateDbContext(string[] args)
//        {
//            var config = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();

//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContextt>();
//            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

//            return new AppDbContextt(optionsBuilder.Options);
//        }
//    }
//}
