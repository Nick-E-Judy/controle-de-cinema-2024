using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinema.Infra.Orm.ModuloGenero;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace ControleDeCinema.WebApp.Controllers
{
    public class FilmeController : Controller
    {
		public ViewResult Listar()
		{
			var dbContext = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(dbContext);

			var filmes = repositorioFilme.SelecionarTodos();

			var listarFilmesVm = filmes
				.Select(f => new ListarFilmeViewModel { Id = f.Id, Titulo = f.Titulo, Sinopse = f.Sinopse, EmExibicao = f.EmExibicao, Lancamento = f.Lancamento, Genero = f.Genero, Duracao = f.Duracao});

			return View(listarFilmesVm);
		}

		public ViewResult Inserir()
		{

			var db = new ControleDeCinemaDbContext();

			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			var generos = repositorioGenero
				.SelecionarTodos()
				.Select(x => new SelectListItem(x.Nome, x.Id.ToString()));

			var inserirFilmeVm = MapearInserirFilmeViewModel(generos);

			return View(inserirFilmeVm);
		}

		[HttpPost]
		public ViewResult Inserir(InserirFilmeViewModel inserirFilmeVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var repositorioGenero = new RepositorioGeneroEmOrm(db);

			if (!ModelState.IsValid)
			{
				inserirFilmeVm.Generos = repositorioGenero
					.SelecionarTodos()
					.Select(x => new SelectListItem(x.Nome, x.Id.ToString()));

				return View(inserirFilmeVm);
			}

			var genero = repositorioGenero.SelecionarPorId(inserirFilmeVm.IdGenero.GetValueOrDefault());
			var filme = new Filme(inserirFilmeVm.Titulo, inserirFilmeVm.Sinopse, inserirFilmeVm.Lancamento, genero, inserirFilmeVm.Duracao);

			repositorioFilme.Inserir(filme);


			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{filme.Id}] foi cadastrado com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			HttpContext.Response.StatusCode = 201;

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Editar(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmeOriginal = repositorioFilme.SelecionarPorId(id);

			var editarFilmeVm = new EditarFilmeViewModel
			{
				Id = id,
				Titulo = filmeOriginal.Titulo,
				Sinopse = filmeOriginal.Sinopse,
				Duracao = filmeOriginal.Duracao,
				EmExibicao = filmeOriginal.EmExibicao,
				Genero = filmeOriginal.Genero,
				Lancamento = filmeOriginal.Lancamento
			};

			return View(editarFilmeVm);
		}

		[HttpPost]
		public ViewResult Editar(EditarFilmeViewModel editarFilmeVm)
		{
			if (!ModelState.IsValid)
				return View(editarFilmeVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmeOriginal = repositorioFilme.SelecionarPorId(editarFilmeVm.Id);

			filmeOriginal.Titulo = editarFilmeVm.Titulo;
			filmeOriginal.Sinopse = editarFilmeVm.Sinopse;
			filmeOriginal.EmExibicao = editarFilmeVm.EmExibicao;
			filmeOriginal.Lancamento = editarFilmeVm.Lancamento;
			filmeOriginal.Genero = editarFilmeVm.Genero;
			filmeOriginal.Duracao = editarFilmeVm.Duracao;

			repositorioFilme.Editar(filmeOriginal);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{filmeOriginal.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmeParaExcluir = repositorioFilme.SelecionarPorId(id);

			var excluirFilmeVm = new ExcluirFilmeViewModel
			{
				Id = id,
				Titulo = filmeParaExcluir.Titulo,
				EmExibicao = filmeParaExcluir.EmExibicao,
				Lancamento = filmeParaExcluir.Lancamento,
				Genero = filmeParaExcluir.Genero,
				Duracao = filmeParaExcluir.Duracao
			};

			return View(excluirFilmeVm);
		}

		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirFilmeViewModel excluirFilmeVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmeParaExcluir = repositorioFilme.SelecionarPorId(excluirFilmeVm.Id);

			repositorioFilme.Excluir(filmeParaExcluir);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{filmeParaExcluir.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmeOriginal = repositorioFilme.SelecionarPorId(id);

			var detalhesFilmeVm = new DetalhesFilmeViewModel
			{
				Id = id,
				Titulo = filmeOriginal.Titulo,
				EmExibicao = filmeOriginal.EmExibicao,
				Lancamento = filmeOriginal.Lancamento,
				Genero = filmeOriginal.Genero,
				Duracao = filmeOriginal.Duracao
			};

			return View(detalhesFilmeVm);
		}

		private InserirFilmeViewModel MapearInserirFilmeViewModel(IEnumerable<SelectListItem> generos)
		{
			return new InserirFilmeViewModel
			{
				Generos = generos.ToList()
			};
		}
	}
}
