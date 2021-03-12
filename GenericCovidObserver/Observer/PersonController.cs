using GenericCovidObserver.Model;
using GenericCovidObserver.Provider;
using System;

namespace GenericCovidObserver.Observer
{
    public class PersonController : IObserver<CovidCell>
    {
        private Person person;
        private IDisposable unsubscriber;

        public PersonController(Person person)
        {
            this.person = person;
        }

        public void OnCompleted()
        {
            Console.WriteLine();
        }

        public virtual void Subscribe(LaboratoryService laboratory)
        {
            unsubscriber = laboratory.Subscribe(this);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(CovidCell covidCell)
        {
            person.IsHealthy = false;
            Console.WriteLine($"{person.Name} {person.Surname} has been infected by a {covidCell.MolecularMass}u covid molecule");
        }
    }
}
