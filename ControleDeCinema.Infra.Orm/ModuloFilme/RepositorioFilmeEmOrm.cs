using ControleDeCinema.Dominio.ModuloAssento;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloFilme;

namespace ControleDeCinema.Infra.Orm.ModuloFilme
{
	public class RepositorioFilmeEmOrm : RepositorioBaseEmOrm<Filme>, IRepositorioFilme
	{
		public RepositorioFilmeEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
		{
		}

		protected override DbSet<Filme> ObterRegistros()
		{
			return dbContext.Filmes;
		}

		public override Filme SelecionarPorId(int id)
		{
			return dbContext.Filmes.FirstOrDefault(f => f.Id == id)!;
		}
	}
}
