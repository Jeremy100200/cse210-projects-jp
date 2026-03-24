using System;
using System.Collections.Generic;
using System.Linq;
using Reference; 

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var reference = new Reference.Reference
            ("John", 3, 16);
            var scripture = new Scripture(reference, "For God so loved the world that he gave his only Son, that whoever believes in him shall not perish but have eternal life.");

            Console.Clear();
            scripture.Display();

            while (true)
            {
                Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
                var input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                    break;

                // Hide one random word
                scripture.HideRandomWords(1);
                Console.Clear();
                scripture.Display();

                if (scripture.IsFullyHidden())
                {
                    Console.WriteLine("\nAll words are hidden! Program will now exit.");
                    break;
                }
            }
        }
    }
}