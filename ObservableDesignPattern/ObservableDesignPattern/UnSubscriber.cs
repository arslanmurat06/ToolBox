using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableDesignPattern
{
    public class UnSubscriber : IDisposable
    {
        private List<IObserver<Duyuru>> _observers;
        private IObserver<Duyuru> _observer;

        public UnSubscriber(List<IObserver<Duyuru>> observers, IObserver<Duyuru> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
