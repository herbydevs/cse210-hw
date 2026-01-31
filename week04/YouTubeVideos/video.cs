using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // The Video class has the responsibility to track the title, author, and length.
    // It also manages a list of comments and provides a count of them.
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; } // Length in seconds
        
        // Encapsulation: The list is private so it can only be modified 
        // through the AddComment method.
        private List<Comment> _comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Abstraction: This method fulfills the requirement to return the number of comments.
        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }
}