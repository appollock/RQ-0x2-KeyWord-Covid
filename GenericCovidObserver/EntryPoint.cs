using GenericCovidObserver.Model;
using GenericCovidObserver.Observer;
using GenericCovidObserver.Provider;
using System;

namespace GenericCovidObserver
{
    class EntryPoint
    {
        private static void Main(string[] args)
        {
            LaboratoryService provider = new LaboratoryService();

            PersonController observerOne = new PersonController(
                new Person(32, true, "Jake", "Smith"));
            PersonController observerTwo = new PersonController(
                new Person(27, true, "Sarah", "Connor"));

            provider.LaboratoryStatus();

            observerOne.Subscribe(provider);

            provider.LaboratoryStatus();

            observerTwo.Subscribe(provider);

            provider.LaboratoryStatus();
        }
    }
}
