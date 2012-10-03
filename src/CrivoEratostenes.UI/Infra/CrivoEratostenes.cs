using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CrivoEratostenes.UI.Infra
{
    public class CrivoEratostenes : ICalculaPrimos
    {
        protected readonly int Limite;
        protected readonly List<int> Valores;
        
        public CrivoEratostenes(int limite)
        {
            Limite = limite;
            Valores = InicializaValores().OrderBy(c=>c).ToList();
        }

        private IEnumerable<int> InicializaValores()
        {
            for (var i = 2; i <= Limite; i++)
            {
                yield return i;
            }
        }

        public virtual ReadOnlyCollection<int> Calcula()
        {
            for (var i = 2; i <= (int)Math.Sqrt(Limite); i++)
            {
                Remove(i);
            }

            return Valores.AsReadOnly();
        }

        protected virtual void Remove(int i)
        {
            lock (this)
            {
                Valores.RemoveAll(c => c%i == 0 && c != i);
            }
        }
    }
}