using System.Linq;
using System.Text;

namespace ParadoxoDeMontyHall.Core
{
    public class Relatorio
    {
        public Relatorio(Cenario cenario, Porta preimiada)
        {
            Cenario = $"{cenario.Referencia}{(cenario.Relatorios.Count() + 1)}";
            Titulo = $"{cenario.Referencia} - {cenario.Titulo}";
            FoiPremiado = cenario.Participante.FoiPremiado();
            PortaEscolhida = cenario.Participante.PortaEscolhida?.ToString();
            PortasEscolhidas = cenario.Participante.HistoricoDePortas.Select(x => x.ToString()).ToArray();
            PortaPremiada = preimiada.ToString();
        }

        public string Cenario { get; set; }

        public string Titulo { get; set; }

        public bool FoiPremiado { get; set; }

        public string PortaEscolhida { get; set; }

        public string PortaPremiada { get; set; }

        public string[] PortasEscolhidas { get; set; }

        public override string ToString()
        {
            StringBuilder resultado = new StringBuilder();

            resultado.Append($"\n - Cenario: {Cenario}");
            resultado.Append($"\n - {Titulo}");
            resultado.Append($"\n - Foi premiado: {FoiPremiado}");
            resultado.Append($"\n - Porta escolhida: {PortaEscolhida}");
            resultado.Append($"\n - Porta premiada: {PortaPremiada}");
            resultado.Append($"\n - Portas escolhidas: {string.Join(", ", PortasEscolhidas)}");
            resultado.Append($"\n");

            return resultado.ToString();
        }
    }
}
