using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the video objects
            List<Video> videos = new List<Video>();

            // --- Create Video 1 ---
            Video video1 = new Video("C# Abstraction Explained", "CodeAcademy", 450);
            video1.AddComment(new Comment("User123", "Finally I understand classes!"));
            video1.AddComment(new Comment("DevGuy", "Excellent pacing on this video."));
            video1.AddComment(new Comment("LearningC", "Could you explain Interfaces next?"));
            videos.Add(video1);

            // --- Create Video 2 ---
            Video video2 = new Video("10 Tips for Better Code", "ProgrammingWithMosh", 1200);
            video2.AddComment(new Comment("CleanCoder", "Rule #3 is the most important."));
            video2.AddComment(new Comment("JuniorDev", "Wish I saw this a year ago."));
            video2.AddComment(new Comment("BugHunter", "Great advice on naming variables."));
            videos.Add(video2);

            // --- Create Video 3 ---
            Video video3 = new Video("Unity Game Dev for Beginners", "Brackets", 1800);
            video3.AddComment(new Comment("GamerGal", "Just finished my first game thanks to you!"));
            video3.AddComment(new Comment("PixelArt", "The lighting section was very helpful."));
            video3.AddComment(new Comment("IndieMaker", "Simple and straightforward tutorial."));
            video3.AddComment(new Comment("Skeptic", "Is Unity better than Godot?"));
            videos.Add(video3);

            // Iterate through the list of videos and display the data
            Console.WriteLine("YouTube Video Awareness Report");
            Console.WriteLine("===============================\n");

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment.Name}: \"{comment.Text}\"");
                }

                Console.WriteLine("\n-------------------------------\n");
            }
        }
    }
}