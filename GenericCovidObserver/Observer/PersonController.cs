using GenericCovidObserver.Model;
using System;

namespace GenericCovidObserver.Observer
{
    public class PersonController : IObserver<CovidCell>
    {
        private Person person;

        public PersonController(Person person)
        {
            this.person = person;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(CovidCell covidCell)
        {
            throw new NotImplementedException();
        }
    }
}
