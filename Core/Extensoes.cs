using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
