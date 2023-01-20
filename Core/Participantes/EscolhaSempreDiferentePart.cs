namespace ParadoxoDeMontyHall.Core.Participantes
{
    public class EscolhaSempreDiferentePart
        : ParticipanteBase
    {
        public override string Titulo => "Escolher sempre uma porta que ainda não escolheu";

        public override Porta? EscolherUmaPorta(List<Porta> opcoes)
        {
            opcoes = opcoes.Where(x => !HistoricoDePortas.Any(y => y.Letra == x.Letra)).ToList();
            if (opcoes.Any())
            {
                int escolhida = Randonico.Next(0, opcoes.Count);
                PortaEscolhida = opcoes[escolhida];
            }
            return PortaEscolhida;
        }
    }
}
