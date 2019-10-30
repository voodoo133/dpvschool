using System;
using Persons;

namespace Turnip
{
    public class Turnip
    {
        public static void pull (Character[] characters)
        {
            var l = new Line();

            foreach (Character character in characters)
            {
                l.add(character);
            }

            //l.add(characters[1]);

            l.pull();
        }
    }
}