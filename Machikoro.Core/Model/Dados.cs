using System.Collections.Generic;
using System.Linq;

namespace Machikoro.Core.Model
{
    public class Dados
    {
        public IEnumerable<int> Resultados { get; set; }

        public Dados(IEnumerable<int> resultados)
        {
            Resultados = resultados;
        }

        public int Total() => Resultados.Sum();

        public override string ToString() => Total().ToString();
        public override bool Equals(object obj) => ((Dados)obj).Total() == Total();
        public override int GetHashCode() => Total().GetHashCode();
    }
}
