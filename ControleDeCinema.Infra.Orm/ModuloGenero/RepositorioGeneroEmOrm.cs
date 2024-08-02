using ControleDeCinema.Dominio.ModuloAssento;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.ModuloGenero;

namespace ControleDeCinema.Infra.Orm.ModuloGenero
{
	public class RepositorioGeneroEmOrm : RepositorioBaseEmOrm<Genero>, IRepositorioGenero
	{
		public RepositorioGeneroEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
		{
		}

		protected override DbSet<Genero> ObterRegistros()
		{
			return dbContext.Generos;
		}

		public override Genero SelecionarPorId(int id)
		{
			return dbContext.Generos.FirstOrDefault(a => a.Id == id)!;
		}
	}
}
