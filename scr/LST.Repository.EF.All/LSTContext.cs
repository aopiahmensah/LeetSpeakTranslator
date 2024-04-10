using LST.Model.Model;
using LST.Model.Model.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LST.Repository.EF.All
{
    public class LSTContext : DbContext
    {
        public LSTContext(DbContextOptions<LSTContext> options) : base(options) { }
        public LSTContext() { }

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies(true);
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("LSTContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApiResponse>()
            //.Property(e => e.JSONResponse)
            //.HasColumnType("json");
        }


        public DbSet<ApiRequest> ApiRequests { get; set; }
        public DbSet<ApiResponse> ApiResponses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
