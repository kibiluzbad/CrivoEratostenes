using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CrivoEratostenes.UI.Infra
{
    public class CrivoEratostenesParallel : UI.Infra.CrivoEratostenes
    {
        private readonly int _maxThreads;

        public CrivoEratostenesParallel(int limite, int maxThreads = -1) : base(limite)
        {
            _maxThreads = maxThreads;
        }

        public override ReadOnlyCollection<int> Calcula()
        {
            Parallel.For(2, ((int) Math.Sqrt(Limite) + 1),
                         new ParallelOptions
                             {
                                 MaxDegreeOfParallelism = _maxThreads
                             },
                         (i, state) => Remove(i));

            return Valores.AsReadOnly();
        }
    }
}