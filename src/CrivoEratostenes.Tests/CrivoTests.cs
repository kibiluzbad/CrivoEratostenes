using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrivoEratostenes.UI.Infra;
using NUnit.Framework;

namespace CrivoEratostenes.Tests
{
    [TestFixture]
    public class CrivoTests
    {
        [Test]
        public void Posso_calcular_numeros_primos_ate_30()
        {
            var limite = 30;

            ICalculaPrimos crivoEratostenes = new UI.Infra.CrivoEratostenes(limite);
            IList<int> valores = crivoEratostenes.Calcula();

            Assert.That(valores.Count(),Is.EqualTo(10));
            Assert.That(valores.Contains(2));
            Assert.That(valores.Contains(3));
            Assert.That(valores.Contains(5));
            Assert.That(valores.Contains(7));
            Assert.That(valores.Contains(11));
            Assert.That(valores.Contains(13));
            Assert.That(valores.Contains(17));
            Assert.That(valores.Contains(19));
            Assert.That(valores.Contains(23));
            Assert.That(valores.Contains(29));
        }

        [Test]
        public void Posso_achar_o_numeros_primos_ate_30_usando_4_threads()
        {
            var limite = 30;
            var maxThreads = 4;

            ICalculaPrimos crivoEratostenes = new CrivoEratostenesParallel(limite,maxThreads);
            IList<int> valores = crivoEratostenes.Calcula();

            Assert.That(valores.Count, Is.EqualTo(10));
            Assert.That(valores.Contains(2));
            Assert.That(valores.Contains(3));
            Assert.That(valores.Contains(5));
            Assert.That(valores.Contains(7));
            Assert.That(valores.Contains(11));
            Assert.That(valores.Contains(13));
            Assert.That(valores.Contains(17));
            Assert.That(valores.Contains(19));
            Assert.That(valores.Contains(23));
            Assert.That(valores.Contains(29));
        }
    }
}
