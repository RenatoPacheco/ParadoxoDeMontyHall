using System.Collections.Generic;
using System.Linq;

namespace ParadoxoDeMontyHall.Core.Participantes
{
    public class EscolhaSemRepetirAhAnteriorPart
        : ParticipanteBase
    {
        public override string Titulo => "Sempre escolher uma diferente da atual";

        public override Porta EscolherUmaPorta(List<Porta> opcoes)
        {
            opcoes = opcoes.Where(x => PortaEscolhida?.Letra != x.Letra).ToList();
            if (opcoes.Any())
            {
                int escolhida = Randonico.Next(0, opcoes.Count);
                PortaEscolhida = opcoes[escolhida];
            }
            return PortaEscolhida;
        }
    }
}
