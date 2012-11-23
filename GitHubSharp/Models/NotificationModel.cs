using System;

namespace GitHubSharp.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public RepositoryModel Repository { get; set; }
        public SubjectModel Subject { get; set; }
        public string Reason { get; set; }
        public bool Unread { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime LastReadAt { get; set; }
        public string Url { get; set; }

        public class SubjectModel
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string LatestCommentUrl { get; set; }
        }
    }
}

