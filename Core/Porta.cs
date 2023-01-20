namespace ParadoxoDeMontyHall.Core
{
    public class Porta
    {
        public static IEnumerable<Porta> PrepararPortas(int quantidade)
        {
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (quantidade < 2)
                throw new ArgumentException("Valor não pde ser menor que 3", nameof(quantidade));

            int premiada = Randonico.Next(0, quantidade);
            for (int i = 0; i < quantidade; i++)
            {
                yield return new Porta
                {
                    Letra = i >= letras.Length ? $"C{i}" : letras[i].ToString(),
                    Premiada = i == premiada
                };
            }
        }

        public string Letra { get; set; } = "empty";

        public bool Premiada { get; set; }

        public override string ToString()
        {
            return $"{Letra} ({Premiada})";
        }
    }
}
