using Microsoft.EntityFrameworkCore;
using ControleDeCinema.Dominio.ModuloAssento;
using ControleDeCinema.Infra.Orm.Compartilhado;

namespace ControleDeCinema.Infra.Orm.ModuloAssento
{
	public class RepositorioAssentoEmOrm : RepositorioBaseEmOrm<Assento>, IRepositorioAssento
	{
		public RepositorioAssentoEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
		{
		}

		protected override DbSet<Assento> ObterRegistros()
		{
			return dbContext.Assentos;
		}

		public override Assento SelecionarPorId(int id)
		{
			return dbContext.Assentos.FirstOrDefault(a => a.Id == id)!;
		}
	}
}
