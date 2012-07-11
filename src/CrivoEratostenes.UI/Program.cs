using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CrivoEratostenes.UI.Infra;

namespace CrivoEratostenes.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int maxThreads;
            
            if(!int.TryParse(args[0],out n)) throw new InvalidOperationException("O primeiro argumento deve ser um inteiro válido");
            if(!int.TryParse(args[1],out maxThreads)) throw new InvalidOperationException("O segundo argumento deve ser um inteiro válido");

            var watch = Stopwatch.StartNew();
            ICalculaPrimos algoritmo = new CrivoEratostenesParallel(n, maxThreads);
            var primos = algoritmo.Calcula();

            Console.WriteLine("{0}.", string.Join(", ", primos.ToArray()));
            Console.WriteLine("Calculado em {0} ms.", watch.ElapsedMilliseconds);
            Console.WriteLine("Digite qualquer tecla para encerrar.");
            Console.ReadLine();
        }
    }
}
