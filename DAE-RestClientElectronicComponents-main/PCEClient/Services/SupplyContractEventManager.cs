using System;
using System.Collections.Generic;

namespace PCEClient.Services
{
    public interface ISupplyContractObserver
    {
        void OnContractsChanged();
    }

    public sealed class SupplyContractEventManager
    {
        private static readonly Lazy<SupplyContractEventManager> _instance =
            new Lazy<SupplyContractEventManager>(() => new SupplyContractEventManager());
        public static SupplyContractEventManager Instance => _instance.Value;

        private readonly List<ISupplyContractObserver> _observers = new List<ISupplyContractObserver>();

        private SupplyContractEventManager() { }

        public void Subscribe(ISupplyContractObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void Unsubscribe(ISupplyContractObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyAll()
        {
            foreach (var observer in _observers.ToArray())
            {
                try { observer.OnContractsChanged(); }
                catch (Exception) { }
            }
        }
    }
}
