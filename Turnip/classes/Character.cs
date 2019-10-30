using System;

namespace Persons 
{
    public class Character
    {
        protected enum CharacterTypes { Human, Animal };
        protected CharacterTypes type { get; set; }
        public string name { get; set; }

        public void pull () 
        {
            Console.Write($"{name} тянет\r\n");
        }
    }
}