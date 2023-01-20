namespace ParadoxoDeMontyHall.Core.Participantes
{
    public class EscolhaAleatoriaPart
        : ParticipanteBase
    {
        public override string Titulo => "Escolha aleatória de portas";

        public override Porta EscolherUmaPorta(List<Porta> opcoes)
        {
            int escolhida = Randonico.Next(0, opcoes.Count);
            PortaEscolhida = opcoes[escolhida];
            return PortaEscolhida;
        }
    }
}
