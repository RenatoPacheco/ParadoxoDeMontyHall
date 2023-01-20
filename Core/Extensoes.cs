using System.Collections.Generic;

namespace ParadoxoDeMontyHall.Core
{
    static class Extensoes
    {
        public static List<T> GetClone<T>(this List<T> source)
        {
            return source.GetRange(0, source.Count);
        }
    }
}
