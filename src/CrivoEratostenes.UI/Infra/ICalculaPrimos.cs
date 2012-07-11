using System.Collections.ObjectModel;

namespace CrivoEratostenes.UI.Infra
{
    public interface ICalculaPrimos
    {
        ReadOnlyCollection<int> Calcula();
    }
}