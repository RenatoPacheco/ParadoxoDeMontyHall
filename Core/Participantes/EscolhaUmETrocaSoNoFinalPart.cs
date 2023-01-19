using System.Collections.Generic;
using System.Linq;

namespace ParadoxoDeMontyHall.Core.Participantes
{
    public class EscolhaUmETrocaSoNoFinalPart
        : ParticipanteBase
    {
        public override string Titulo => "Fazer uma escolha e trocar só no final";

        public override Porta EscolherUmaPorta(List<Porta> opcoes)
        {
            if (opcoes.Any() && (PortaEscolhida == null || opcoes.Count == 2))
            {
                opcoes = opcoes.Where(x => !HistoricoDePortas.Any(y => y.Letra == x.Letra)).ToList();
                int escolhida = Randonico.Next(0, opcoes.Count);
                PortaEscolhida = opcoes[escolhida];
            }
            return PortaEscolhida;
        }
    }
}
