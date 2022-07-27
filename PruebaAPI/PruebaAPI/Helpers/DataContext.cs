namespace PruebaAPI.Helpers
{
    using Microsoft.EntityFrameworkCore;
    using PruebaAPI.Entities;

    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("ApiMysqlBD");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }

}
