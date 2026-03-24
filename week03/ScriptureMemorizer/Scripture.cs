using System;
using System.Collections.Generic;
using System.Linq; 
using ScriptureMemorizer;

namespace Reference
{
    public class Scripture
    {
        public Reference Reference { get; private set; }
        public List<Word> Words { get; private set; } 
        public Scripture(Reference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList(); 
        }

        public void Display()
        {
            Console.WriteLine(Reference.ToString());
            Console.WriteLine(string.Join(" ", Words.Select(word => word.GetDisplayText())));
        }

        public void HideRandomWords(int count)
        {
            Random random = new Random(); 
            for (int i = 0; i < count; i++)
            {
                var visibleWords = Words.Where(word => !word.IsHidden).ToList();
                if (visibleWords.Any()) 
                {
                    var wordToHide = visibleWords[random.Next(visibleWords.Count)]; // Fixed property name
                    wordToHide.Hide();
                }
            }
        }

        public bool IsFullyHidden()
        {
            return Words.All(word => word.IsHidden);
        }
    }
}