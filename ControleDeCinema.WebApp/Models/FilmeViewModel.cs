using System.ComponentModel.DataAnnotations;
using ControleDeCinema.Dominio.ModuloGenero;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeCinema.WebApp.Models
{
	public class InserirFilmeViewModel
	{
		[Required(ErrorMessage = "O campo Título é obrigatório!")]
		[MinLength(2, ErrorMessage = "O campo Título necessita de ao menos 2 caracteres")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "O campo Sinopse é obrigatório!")]
		public string Sinopse { get; set; }

		[Required(ErrorMessage = "O campo Lançamento é obrigatório!")]
		public DateTime Lancamento { get; set; }

		[Required(ErrorMessage = "O campo Gênero é obrigatório!")]
		public int? IdGenero { get; set; }

		[Required(ErrorMessage = "O campo Duração é obrigatório!")]
		public TimeSpan Duracao { get; set; }
		public IEnumerable<SelectListItem>? Generos { get; set; }
	}

	public class EditarFilmeViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Título é obrigatório!")]
		[MinLength(2, ErrorMessage = "O campo Título necessita de ao menos 2 caracteres")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "O campo Sinopse é obrigatório!")]
		public string Sinopse { get; set; }

		public bool EmExibicao { get; set; }

		[Required(ErrorMessage = "O campo Lançamento é obrigatório!")]
		public DateTime Lancamento { get; set; }

		[Required(ErrorMessage = "O campo Gênero é obrigatório!")]
		public Genero Genero { get; set; }

		[Required(ErrorMessage = "O campo Duração é obrigatório!")]
		public TimeSpan Duracao { get; set; }
	}

	public class ExcluirFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Sinopse { get; set; }
		public bool EmExibicao { get; set; }
		public DateTime Lancamento { get; set; }
		public Genero Genero { get; set; }
		public TimeSpan Duracao { get; set; }
	}

	public class ListarFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Sinopse { get; set; }
		public bool EmExibicao { get; set; }
		public DateTime Lancamento { get; set; }
		public Genero Genero { get; set; }
		public TimeSpan Duracao { get; set; }
	}

	public class DetalhesFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Sinopse { get; set; }
		public bool EmExibicao { get; set; }
		public DateTime Lancamento { get; set; }
		public Genero Genero { get; set; }
		public TimeSpan Duracao { get; set; }
	}
}