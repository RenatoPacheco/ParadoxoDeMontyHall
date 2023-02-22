using System.ComponentModel.DataAnnotations;

namespace ParadoxoDeMontyHall.Core.Participantes
{
    public abstract class ParticipanteBase
    {
        private readonly List<Porta> _historicoDePortas = new();
        [Display(Name = "Historico de portas")]
        public Porta[] HistoricoDePortas => _historicoDePortas.ToArray();

        private Porta? _portaEscolhida;
        [Display(Name = "Porta escolhida")]
        public Porta? PortaEscolhida
        {
            get => _portaEscolhida;
            set
            {
                if (_portaEscolhida != value)
                {
                    _portaEscolhida = value;
                    if (value is null)
                    {
                        _historicoDePortas.Clear();
                    }
                    else
                    {
                        _historicoDePortas.Add(value);
                    }
                }
            }
        }

        [Display(Name = "Título")]
        public abstract string Titulo { get; }

        public override string ToString()
        {
            return PortaEscolhida?.ToString() ?? "null - null";
        }

        public void Limpar()
        {
            _historicoDePortas.Clear();
            _portaEscolhida = null;
        }

        public abstract Porta? EscolherUmaPorta(List<Porta> opcoes);

        public bool FoiPremiado()
        {
            return PortaEscolhida?.Premiada ?? false;
        }
    }
}
