using System;
using System.Collections.Generic;
using Persons;

namespace Turnip 
{
    public class Line
    {
        private List<Character> characterList = new List<Character>() {};

        public void add (Character c)
        {
            if (!characterList.Contains(c))
                characterList.Add(c);
            else 
                Console.WriteLine($"{c.name} уже добавлен");
        }

        public void pull ()
        {
            if (characterList.Count != 6) {
                Console.WriteLine("Не хватает людей для совершения операции по вытягиванию репки");
                return;
            }

            Console.WriteLine("Персонажи тянут: ");

            characterList.ForEach(delegate(Character c) {
                c.pull();
            });
        }
    }
}