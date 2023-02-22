namespace ParadoxoDeMontyHall.Core
{
    public static class Randonico
    {
        private static readonly Random _rdn = new();

        public static int Next(int inicio, int quantidade)
        {
            return _rdn.Next(inicio, quantidade);
        }
    }
}
