using System.Text;
using System.ComponentModel.DataAnnotations;
using ParadoxoDeMontyHall.Core.Participantes;

namespace ParadoxoDeMontyHall.Core
{
    public class Cenario
    {
        public Cenario(ParticipanteBase participante, string referencia)
        {
            if (participante is null)
                throw new ArgumentException("Valor não pode ser nulo", nameof(participante));

            Participante = participante;
            Referencia = referencia;
            Titulo = participante.Titulo;
        }

        public ParticipanteBase Participante { get; }

        public string Titulo { get; }

        public string Referencia { get; }

        private readonly List<Relatorio> _relatorios = new();
        [Display(Name = "Relatorios")]
        public Relatorio[] Relatorios => _relatorios.ToArray();

        public void Limpar()
        {
            _relatorios.Clear();
        }

        public Relatorio Executar(List<Porta> portas)
        {
            if (portas.Count < 3)
                throw new ArgumentException("Valor não pode ser nulo, ou ter menos de 3 itens", nameof(portas));

            List<Porta> opcoes = portas.GetClone();
            Porta premiada = opcoes.Where(x => x.Premiada).First();
            Participante.Limpar();

            while (opcoes.Count > 2)
            {
                Participante.EscolherUmaPorta(opcoes);
                opcoes = AbrirUmaPorta(opcoes);
            }
            Participante.EscolherUmaPorta(opcoes);

            Relatorio relatorio = new(this, premiada);
            _relatorios.Add(relatorio);

            return relatorio;
        }

        public string Analisar()
        {
            StringBuilder resultado = new();
            decimal total = _relatorios.Count();


            resultado.Append($"{Referencia} - {Titulo}\n");

            resultado.Append($"\nTotal {total} (100%)");

            decimal faixa = _relatorios.Where(x => x.FoiPremiado).Count();
            decimal percentual = faixa * 100 / total;

            resultado.Append($"\nTotal de acertos {faixa} ({percentual}%)");

            faixa = _relatorios.Where(x => !x.FoiPremiado).Count();
            percentual = _relatorios.Where(x => !x.FoiPremiado).Count();
            percentual = faixa * 100 / total;

            resultado.Append($"\nTotal de erros {faixa} ({percentual}%)\n");

            return resultado.ToString();
        }

        private List<Porta> AbrirUmaPorta(List<Porta> portas)
        {
            List<Porta> portasParaAbrir = portas.Where(
                x => x.Letra != Participante.PortaEscolhida?.Letra
                && x.Premiada == false).ToList();

            int posicaoAberta = Randonico.Next(0, portasParaAbrir.Count);
            portas.Remove(portasParaAbrir[posicaoAberta]);

            return portas;
        }
    }
}
