namespace Reference;

public class Reference
{
    public string Book {get; private set; }
    public int Chapter {get; private set; }
    public int? StartVerse {get; private set; }
    public int? EndVerse {get; private set; }
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }
    public Reference(string book, int chapter, int startverse, int endverse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startverse;
        EndVerse = endverse;
    }

    public override string ToString()
    {
       if(EndVerse.HasValue)
        {
            return $"{Book} {Chapter}: {StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}: {StartVerse}";
        }
    }

}
