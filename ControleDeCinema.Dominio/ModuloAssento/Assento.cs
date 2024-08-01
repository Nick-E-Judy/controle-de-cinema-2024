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
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Assento assentoAtualizado = (Assento)registroAtualizado;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            return erros;
        }
    }
}
