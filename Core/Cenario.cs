using ParadoxoDeMontyHall.Core.Participantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ParadoxoDeMontyHall.Core
{
    public class Cenario
    {
        public Cenario(ParticipanteBase participante, string referencia)
        {
            if (participante is null)
                throw new ArgumentException("Valo não pode ser nulo", nameof(participante));

            _participante = participante;
            _referencia = referencia;
            _titulo = participante.Titulo;
        }

        private readonly ParticipanteBase _participante;
        public ParticipanteBase Participante => _participante;

        private readonly string _titulo;
        public string Titulo => _titulo;

        private readonly string _referencia;
        public string Referencia => _referencia;

        private readonly List<Relatorio> _relatorios = new List<Relatorio>();
        [Display(Name = "Relatorios")]
        public Relatorio[] Relatorios => _relatorios.ToArray();

        public void Limpar()
        {
            _relatorios.Clear();
        }

        public Relatorio Executar(List<Porta> portas)
        {
            if (portas.Count < 3)
                throw new ArgumentException("Valor não pode ser nulo, ou ter menos de 3 itens", nameof(Porta));

            List<Porta> opcoes = portas.GetClone();
            Porta premiada = opcoes.Where(x => x.Premiada).First();
            _participante.Limpar();

            while (opcoes.Count > 2)
            {
                _participante.EscolherUmaPorta(opcoes);
                opcoes = AbrirUmaPorta(opcoes);
            }
            _participante.EscolherUmaPorta(opcoes);

            Relatorio relatorio = new Relatorio(this, premiada);
            _relatorios.Add(relatorio);

            return relatorio;
        }

        public string Analisar()
        {
            StringBuilder resultado = new StringBuilder();
            decimal total = _relatorios.Count();


            resultado.Append($"{_referencia} - {_titulo}\n");

            resultado.Append($"\nTotal {total} (100%)");

            decimal faixa = _relatorios.Where(x => x.FoiPremiado).Count();
            decimal percentual = (faixa * 100) / total;

            resultado.Append($"\nTotal de acertos {faixa} ({percentual}%)");

            faixa = _relatorios.Where(x => !x.FoiPremiado).Count();
            percentual = _relatorios.Where(x => !x.FoiPremiado).Count();
            percentual = (faixa * 100) / total;

            resultado.Append($"\nTotal de erros {faixa} ({percentual}%)\n");

            return resultado.ToString();
        }

        private List<Porta> AbrirUmaPorta(List<Porta> portas)
        {
            List<Porta> portasParaAbrir = portas.Where(
               x => x.Letra != _participante.PortaEscolhida.Letra
               && x.Premiada == false).ToList();

            int posicaoAberta = Randonico.Next(0, portasParaAbrir.Count);
            portas.Remove(portasParaAbrir[posicaoAberta]);

            return portas;
        }
    }
}
