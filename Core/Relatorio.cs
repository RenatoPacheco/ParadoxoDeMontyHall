using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ParadoxoDeMontyHall.Core
{
    public class Relatorio
    {
        public Relatorio(Cenario cenario, Porta preimiada)
        {
            Cenario = $"{cenario.Referencia}{cenario.Relatorios.Length + 1}";
            Titulo = $"{cenario.Referencia} - {cenario.Titulo}";
            FoiPremiado = cenario.Participante.FoiPremiado();
            PortaEscolhida = cenario.Participante.PortaEscolhida?.ToString() ?? "empty";
            PortasEscolhidas = cenario.Participante.HistoricoDePortas.Select(x => x.ToString()).ToArray();
            PortaPremiada = preimiada.ToString();
        }

        [Display(Name = "Cenário")]
        public string Cenario { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Foi premiado")]
        public bool FoiPremiado { get; set; }

        [Display(Name = "Porta escolhida")]
        public string PortaEscolhida { get; set; }

        [Display(Name = "Porta premiada")]
        public string PortaPremiada { get; set; }

        [Display(Name = "Portas escolhidas")]
        public string[] PortasEscolhidas { get; set; }

        public override string ToString()
        {
            StringBuilder resultado = new();

            resultado.Append($"\n - Cenário: {Cenario}");
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
