using ControleDeCinema.Dominio.ModuloAssento;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Compartilhado
{
    public class ControleDeCinemaDbContext : DbContext
    {
        public DbSet<Assento> Assentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("SqlServer")!;

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assento>(assentoBuilder =>
            {
                assentoBuilder.ToTable("TBAssento");

                assentoBuilder.Property(a => a.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
