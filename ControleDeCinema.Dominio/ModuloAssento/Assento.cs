using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloAssento
{
    public class Assento : EntidadeBase
    {
        public string Posicao { get; set; }
        public bool Ocupado { get; set; }

        public Assento()
        {
	    
        }

		public Assento(string posicao, bool ocupado)
        {
            Posicao = posicao;
            Ocupado = ocupado;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Assento assentoAtualizado = (Assento)registroAtualizado;

            Posicao = assentoAtualizado.Posicao;
            Ocupado = assentoAtualizado.Ocupado;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Posicao.Trim()))
	            erros.Add("O campo \"Posicao\" é obrigatório!");

			return erros;
        }

        public override string ToString()
        {
	        return Posicao;
        }
	}
}
