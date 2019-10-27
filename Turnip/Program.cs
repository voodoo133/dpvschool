using System;
using Persons;

namespace Turnip
{
    class Program
    {
        static void Main(string[] args)
        {
            Character[] characters = new Character[6] {
                new Mouse(),
                new Cat(),
                new Dog(),
                new Granddaughter(),
                new Grandmother(),
                new Grandfather()
            };

            Turnip.pull(characters);
        }
    }

}
