using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models
{
	public class InserirAssentoViewModel
	{
		[Required(ErrorMessage = "O campo posicao é obrigatório!")]
		[MinLength(2, ErrorMessage = "O campo posicao necessita de ao menos 2 caracteres")]
		public string Posicao { get; set; }

		[Required(ErrorMessage = "O campo Ocupado é obrigatório!")]
	
		public bool Ocupado { get; set; }
	}

	public class EditarAssentoViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo posicao é obrigatório!")]
		[MinLength(2, ErrorMessage = "O campo posicao necessita de ao menos 2 caracteres")]
		public string Posicao { get; set; }

		[Required(ErrorMessage = "O campo Ocupado é obrigatório!")]
		
		public bool Ocupado { get; set; }
	}

	public class ExcluirAssentoViewModel
	{
		public int Id { get; set; }
		public string Posicao { get; set; }
		public bool Ocupado { get; set; }
	}

	public class ListarAssentoViewModel
	{
		public int Id { get; set; }
		public string Posicao { get; set; }
		public bool Ocupado { get; set; }
	}

	public class DetalhesAssentoViewModel
	{
		public int Id { get; set; }
		public string Posicao { get; set; }
		public bool Ocupado { get; set; }
	}
}
