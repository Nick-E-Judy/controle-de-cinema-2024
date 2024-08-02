using ControleDeCinema.Dominio.ModuloAssento;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloAssento;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
    public class AssentoController : Controller
    {
		public ViewResult Listar()
		{
			var dbContext = new ControleDeCinemaDbContext();
			var repositorioAssento = new RepositorioAssentoEmOrm(dbContext);

			var assentos = repositorioAssento.SelecionarTodos();

			var listarAssentosVm = assentos
				.Select(a => new ListarAssentoViewModel { Id = a.Id, Posicao = a.Posicao, Ocupado = a.Ocupado });

			return View(listarAssentosVm);
		}

		public ViewResult Inserir()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Inserir(InserirAssentoViewModel inserirAssentoVm)
		{
			if (!ModelState.IsValid)
				return View(inserirAssentoVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioAssento = new RepositorioAssentoEmOrm(db);

			var assento = new Assento(inserirAssentoVm.Posicao, inserirAssentoVm.Ocupado);

			repositorioAssento.Inserir(assento);

			HttpContext.Response.StatusCode = 201;

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{assento.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/assento/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Editar(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioAssento = new RepositorioAssentoEmOrm(db);

			var assentoOriginal = repositorioAssento.SelecionarPorId(id);

			var editarAssentoVm = new EditarAssentoViewModel
			{
				Id = id,
				Posicao = assentoOriginal.Posicao,
				Ocupado = assentoOriginal.Ocupado
			};

			return View(editarAssentoVm);
		}

		[HttpPost]
		public ViewResult Editar(EditarAssentoViewModel editarAssentoVm)
		{
			if (!ModelState.IsValid)
				return View(editarAssentoVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioAssento = new RepositorioAssentoEmOrm(db);

			var assentoOriginal = repositorioAssento.SelecionarPorId(editarAssentoVm.Id);

			assentoOriginal.Posicao = editarAssentoVm.Posicao;
			assentoOriginal.Ocupado = editarAssentoVm.Ocupado;

			repositorioAssento.Editar(assentoOriginal);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{assentoOriginal.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/assento/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioAssento = new RepositorioAssentoEmOrm(db);

			var assentoParaExcluir = repositorioAssento.SelecionarPorId(id);

			var excluirAssentoVm = new ExcluirAssentoViewModel
			{
				Id = id,
				Posicao = assentoParaExcluir.Posicao,
				Ocupado = assentoParaExcluir.Ocupado
			};

			return View(excluirAssentoVm);
		}

		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirAssentoViewModel excluirAssentoVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioAssento = new RepositorioAssentoEmOrm(db);

			var assentoParaExcluir = repositorioAssento.SelecionarPorId(excluirAssentoVm.Id);

			repositorioAssento.Excluir(assentoParaExcluir);

			var notificacaoVm = new NotificacaoViewModel
			{
				Mensagem = $"O registro com o ID [{assentoParaExcluir.Id}] foi excluído com sucesso!",
				LinkRedirecionamento = "/assento/listar"
			};

			return View("mensagens", notificacaoVm);
		}

		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioAssento = new RepositorioAssentoEmOrm(db);

			var assentoOriginal = repositorioAssento.SelecionarPorId(id);

			var detalhesAssentoVm = new DetalhesAssentoViewModel
			{
				Id = id,
				Posicao = assentoOriginal.Posicao,
				Ocupado = assentoOriginal.Ocupado
			};

			return View(detalhesAssentoVm);
		}
	}
}
