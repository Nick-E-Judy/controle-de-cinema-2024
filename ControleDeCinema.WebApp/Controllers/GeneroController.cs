using ControleDeCinema.Dominio.ModuloGenero;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloGenero;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
    public class GeneroController : Controller
    {
		public ViewResult Listar()
		{
			var dbContext = new ControleDeCinemaDbContext();
			var repositorioGenero = new RepositorioGeneroEmOrm(dbContext);

			var generos = repositorioGenero.SelecionarTodos();

			var listarGenerosVm = generos
				.Select(g => new ListarGeneroViewModel { Id = g.Id, Nome = g.Nome, Descricao = g.Descricao});

			return View(listarGenerosVm);
		}

		public ViewResult Inserir()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Inserir(InserirGeneroViewModel inserirGeneroVm)
		{
			if (!ModelState.IsValid)
				return View(inserirGeneroVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			var genero = new Genero(inserirGeneroVm.Nome, inserirGeneroVm.Descricao);

			repositorioGenero.Inserir(genero);

			HttpContext.Response.StatusCode = 201;

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{genero.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/genero/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Editar(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			var generoOriginal = repositorioGenero.SelecionarPorId(id);

			var editarGeneroVm = new EditarGeneroViewModel
			{
				Id = id,
				Nome = generoOriginal.Nome,
				Descricao = generoOriginal.Descricao
			};

			return View(editarGeneroVm);
		}

		[HttpPost]
		public ViewResult Editar(EditarGeneroViewModel editarGeneroVm)
		{
			if (!ModelState.IsValid)
				return View(editarGeneroVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			var generoOriginal = repositorioGenero.SelecionarPorId(editarGeneroVm.Id);

			generoOriginal.Nome = editarGeneroVm.Nome;
			generoOriginal.Descricao = editarGeneroVm.Descricao;

			repositorioGenero.Editar(generoOriginal);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{generoOriginal.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/genero/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			var generoParaExcluir = repositorioGenero.SelecionarPorId(id);

			var excluirGeneroVm = new ExcluirGeneroViewModel
			{
				Id = id,
				Nome = generoParaExcluir.Nome,
				Descricao = generoParaExcluir.Descricao
			};

			return View(excluirGeneroVm);
		}

		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirGeneroViewModel excluirGeneroVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			var generoParaExcluir = repositorioGenero.SelecionarPorId(excluirGeneroVm.Id);

			repositorioGenero.Excluir(generoParaExcluir);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{generoParaExcluir.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/genero/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			var generoOriginal = repositorioGenero.SelecionarPorId(id);

			var detalhesGeneroVm = new DetalhesGeneroViewModel
			{
				Id = id,
				Nome = generoOriginal.Nome,
				Descricao = generoOriginal.Descricao
			};

			return View(detalhesGeneroVm);
		}
	}
}
