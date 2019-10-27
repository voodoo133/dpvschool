using System;
using Persons;

namespace Turnip
{
    class Program
    {
        static void Main(string[] args)
        {
            var mouse = new Mouse();
            var cat = new Cat();
            var dog = new Dog();
            var granddaughter = new Granddaughter();
            var grandmother = new Grandmother();
            var grandfather = new Grandfather();

            var l = new Line();

            l.add(grandfather);
            l.add(grandmother);
            l.add(granddaughter);
            l.add(dog);
            l.add(cat);
            l.add(mouse);

            l.pull();
        }
    }
}
