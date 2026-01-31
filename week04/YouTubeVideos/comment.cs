using System;

namespace YouTubeVideos
{
    // The Comment class has the responsibility for tracking both 
    // the name of the person who made the comment and the text of the comment.
    public class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}