using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloAssento;

namespace ControleDeCinema.Dominio.ModuloGenero
{
    public class Genero : EntidadeBase
    {
	    public string Nome { get; set; }
	    public string Descricao { get; set; }

	    public Genero()
	    {

	    }

	    public Genero(string nome, string descricao)
	    {
			Nome = nome;
			Descricao = descricao;
	    }

	    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
	    {
		    Genero generoAtualizado = (Genero)registroAtualizado;

		    Nome = generoAtualizado.Nome;
		    Descricao = generoAtualizado.Descricao;
	    }

	    public override List<string> Validar()
	    {
		    List<string> erros = new List<string>();

		    if (string.IsNullOrEmpty(Nome.Trim()))
			    erros.Add("O campo \"Nome\" é obrigatório!");
		    if (string.IsNullOrEmpty(Descricao.Trim()))
			    erros.Add("O campo \"Descrição\" é obrigatório!");

		    return erros;
	    }
    }
}

