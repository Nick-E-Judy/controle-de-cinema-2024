using ControleDeCinema.Dominio.ModuloAssento;
using ControleDeCinema.Dominio.ModuloGenero;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Compartilhado
{
    public class ControleDeCinemaDbContext : DbContext
    {
        public DbSet<Assento> Assentos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        
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

                assentoBuilder.Property(a => a.Posicao)
	                .IsRequired()
	                .HasColumnType("varchar(100)");

                assentoBuilder.Property(a => a.Ocupado)
	                .IsRequired()
	                .HasColumnType("bit");
			});

            modelBuilder.Entity<Genero>(assentoBuilder =>
            {
	            assentoBuilder.ToTable("TBGenero");

	            assentoBuilder.Property(g => g.Id)
		            .IsRequired()
		            .ValueGeneratedOnAdd();

	            assentoBuilder.Property(g => g.Nome)
		            .IsRequired()
		            .HasColumnType("varchar(250)");

	            assentoBuilder.Property(g => g.Descricao)
		            .IsRequired()
		            .HasColumnType("varchar(500)");
            });

			base.OnModelCreating(modelBuilder);
        }
    }
}
