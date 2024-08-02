using ControleDeCinema.Dominio.ModuloAssento;
using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.Dominio.ModuloFilme;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Compartilhado
{
	public class ControleDeCinemaDbContext : DbContext
	{
		public DbSet<Assento> Assentos { get; set; }
		public DbSet<Genero> Generos { get; set; }
		public DbSet<Filme> Filmes { get; set; }

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

			modelBuilder.Entity<Genero>(generoBuilder =>
			{
				generoBuilder.ToTable("TBGenero");

				generoBuilder.Property(g => g.Id)
					.IsRequired()
					.ValueGeneratedOnAdd();

				generoBuilder.Property(g => g.Nome)
					.IsRequired()
					.HasColumnType("varchar(250)");

				generoBuilder.Property(g => g.Descricao)
					.IsRequired()
					.HasColumnType("varchar(500)");
			});

			modelBuilder.Entity<Filme>(filmeBuilder =>
			{
				filmeBuilder.ToTable("TBFilme");

				filmeBuilder.Property(f => f.Id)
					.IsRequired()
					.ValueGeneratedOnAdd();

				filmeBuilder.Property(f => f.Titulo)
					.IsRequired()
					.HasColumnType("varchar(250)");

				filmeBuilder.Property(f => f.Sinopse)
					.IsRequired()
					.HasColumnType("varchar(1000)");

				filmeBuilder.Property(f => f.EmExibicao)
					.IsRequired()
					.HasColumnType("bit");

				filmeBuilder.Property(f => f.Lancamento)
					.IsRequired()
					.HasColumnType("date");

				filmeBuilder.Property(f => f.Duracao)
					.IsRequired()
					.HasColumnType("time");

				filmeBuilder.HasOne(f => f.Genero)
					.WithMany()
					.HasForeignKey("Genero_Id")
					.IsRequired();
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
