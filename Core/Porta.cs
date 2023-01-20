namespace ParadoxoDeMontyHall.Core
{
    public class Porta
    {
        public static List<Porta> PrepararPortas(int quantidade)
        {
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (quantidade < 2)
                throw new ArgumentException("Valor não pde ser menor que 3", nameof(quantidade));

            List<Porta> resultado = new();
            int premiada = Randonico.Next(0, quantidade);
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(new Porta
                {
                    Letra = i >= letras.Length ? $"C{i}" : letras[i].ToString(),
                    Premiada = i == premiada
                });
            }

            return resultado;
        }

        public string Letra { get; set; } = "empty";

        public bool Premiada { get; set; }

        public override string ToString()
        {
            return $"{Letra} ({Premiada})";
        }
    }
}
