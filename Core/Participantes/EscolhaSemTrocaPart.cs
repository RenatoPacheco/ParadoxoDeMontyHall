namespace ParadoxoDeMontyHall.Core.Participantes
{
    public class EscolhaSemTrocaPart
        : ParticipanteBase
    {
        public override string Titulo => "Fazer uma escolha e não trocar mais";

        public override Porta? EscolherUmaPorta(List<Porta> opcoes)
        {
            if (PortaEscolhida is null)
            {
                int escolhida = Randonico.Next(0, opcoes.Count);
                PortaEscolhida = opcoes[escolhida];
            }
            return PortaEscolhida;
        }
    }
}
