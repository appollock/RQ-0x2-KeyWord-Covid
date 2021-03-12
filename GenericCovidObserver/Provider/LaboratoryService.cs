using GenericCovidObserver.Model;
using System;
using System.Collections.Generic;

namespace GenericCovidObserver.Provider
{
    public class LaboratoryService : IObservable<CovidCell>
    {
        private List<IObserver<CovidCell>> observers;
        private List<CovidCell> covidCells;
        private Random randomizer;

        public LaboratoryService()
        {
            InitializeLaboratoryService();
        }

        private void InitializeLaboratoryService()
        {
            observers = new List<IObserver<CovidCell>>();
            covidCells = new List<CovidCell>();

            randomizer = new Random();
            for (int i = 0; i < randomizer.Next(1, 8); i++)
            {
                covidCells.Add(new CovidCell(randomizer.Next(128, 180)));
            }
        }

        public IDisposable Subscribe(IObserver<CovidCell> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                foreach (var item in covidCells)
                {
                    observer.OnNext(item);
                }
            }
            return new Unsubscriber<CovidCell>(observers, observer);
        }

        public void LaboratoryStatus()
        {
            CovidCell covidCell = new CovidCell(randomizer.Next(128, 180));

            covidCells.Add(covidCell);
            foreach (var observer in observers)
            {
                observer.OnNext(covidCell);
            }
        }

        public void SterilizeLaboratory()
        {
            covidCells.Clear();
        }

        public void LastCovidCellSentOrPassed()
        {
            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }
            observers.Clear();
        }

        private class Unsubscriber<CovidCell> : IDisposable
        {
            private List<IObserver<CovidCell>> internalObservers;
            private IObserver<CovidCell> internalObserver;

            public Unsubscriber(List<IObserver<CovidCell>> internalObservers, IObserver<CovidCell> internalObserver)
            {
                this.internalObservers = internalObservers;
                this.internalObserver = internalObserver;
            }

            public void Dispose()
            {
                if (!internalObservers.Contains(internalObserver))
                {
                    internalObservers.Remove(internalObserver);
                }
            }
        }
    }
}
