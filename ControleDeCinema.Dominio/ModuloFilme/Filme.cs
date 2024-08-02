using System;
using System.Collections.Generic;
using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloGenero;

namespace ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme : EntidadeBase
    {
		public string Titulo { get; set; }
		public string Sinopse { get; set; }
		public bool EmExibicao { get; set; }
		public DateTime Lancamento { get; set; }
		public Genero Genero { get; set; }
		public TimeSpan Duracao { get; set; }

		public Filme()
		{

		}

		public Filme(string titulo, string sinopse, DateTime lancamento, Genero genero, TimeSpan duracao)
		{
			Titulo = titulo;
			Sinopse = sinopse;
			EmExibicao = false;
			Lancamento = lancamento;
			Genero = genero;
			Duracao = duracao;
		}
		public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
		{
			Filme filmeAtualizado = (Filme)registroAtualizado;

			Titulo = filmeAtualizado.Titulo;
			Sinopse = filmeAtualizado.Sinopse;
			EmExibicao = filmeAtualizado.EmExibicao;
			Lancamento = filmeAtualizado.Lancamento;
			Genero = filmeAtualizado.Genero;
			Duracao = filmeAtualizado.Duracao;
		}

		public override List<string> Validar()
		{
			List<string> erros = new List<string>();

			if (string.IsNullOrEmpty(Titulo.Trim()))
				erros.Add("O campo \"Título\" é obrigatório!");

			return erros;
		}
	}
}