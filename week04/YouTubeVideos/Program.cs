using System;
using System.Collections.Generic;

namespace YoutubeTracker
{
    class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        // in seconds
        public int Length { get; set; }  
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }

        // Renamed to accurately describe what this method does
        public void DisplayComments()
        {
            foreach (var comment in Comments)
            {
                Console.WriteLine($"  - {comment.CommenterName}: \"{comment.Text}\"");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Video video1 = new Video("C# Tutorial", "John Doe", 600);
            video1.AddComment(new Comment("Moses", "Great lecture!"));
            video1.AddComment(new Comment("Joseph", "That was helpful, thanks!"));

            Video video2 = new Video("Learn cSharp", "John Kamara", 900);
            video2.AddComment(new Comment("Ibrahim", "Awesome content!"));
            video2.AddComment(new Comment("David", "I learned a lot, thank you!"));

            List<Video> videos = new List<Video> { video1, video2 };

            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                video.DisplayComments();  
                Console.WriteLine();
            }
        }
    }
}