using System;
using System.Collections.Generic;

namespace GitHubSharp.Models
{
    
    public class EventModel
    {
        private Dictionary<string, object> _payload;
        private string _type;

		public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                DeserializePayloadObject();
            }
        }

        public bool Public { get; set; }

        public Dictionary<string, object> Payload
        {
            get { return _payload; }
            set
            {
                _payload = value;
                DeserializePayloadObject();
            }
        }

        public object PayloadObject { get; private set; }

        public RepoModel Repo { get; set; }
        public BasicUserModel Actor { get; set; }
        public BasicUserModel Org { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
        public string Id { get; set; }

        private void DeserializePayloadObject()
        {
            if (Type == null || _payload == null || PayloadObject != null)
                return;

            try
            {
                // The deserialize function on the JsonSerializer.Deserializer only takes a IResponse object.
                // So, we'll just do what we have to to create one which is just assigning it's content to our payload.
                var payout = Client.Serializer.Serialize(_payload);

                switch (Type)
                {
                    case "CommitCommentEvent":
                        PayloadObject = Client.Serializer.Deserialize<CommitCommentEvent>(payout);
                        return;
                    case "CreateEvent":
						PayloadObject = Client.Serializer.Deserialize<CreateEvent>(payout);
                        return;
                    case "DeleteEvent":
						PayloadObject = Client.Serializer.Deserialize<DeleteEvent>(payout);
                        return;
                    case "DownloadEvent":
						PayloadObject = Client.Serializer.Deserialize<DownloadEvent>(payout);
                        return;
                    case "FollowEvent":
						PayloadObject = Client.Serializer.Deserialize<FollowEvent>(payout);
                        return;
                    case "ForkEvent":
						PayloadObject = Client.Serializer.Deserialize<ForkEvent>(payout);
                        return;
                    case "ForkApplyEvent":
						PayloadObject = Client.Serializer.Deserialize<ForkApplyEvent>(payout);
                        return;
                    case "GistEvent":
						PayloadObject = Client.Serializer.Deserialize<GistEvent>(payout);
                        return;
                    case "GollumEvent":
						PayloadObject = Client.Serializer.Deserialize<GollumEvent>(payout);
                        return;
                    case "IssueCommentEvent":
						PayloadObject = Client.Serializer.Deserialize<IssueCommentEvent>(payout);
                        return;
                    case "IssuesEvent":
						PayloadObject = Client.Serializer.Deserialize<IssuesEvent>(payout);
                        return;
                    case "MemberEvent":
						PayloadObject = Client.Serializer.Deserialize<MemberEvent>(payout);
                        return;
                    case "PublicEvent":
						PayloadObject = Client.Serializer.Deserialize<PublicEvent>(payout);
                        return;
                    case "PullRequestEvent":
						PayloadObject = Client.Serializer.Deserialize<PullRequestEvent>(payout);
                        return;
                    case "PullRequestReviewCommentEvent":
						PayloadObject = Client.Serializer.Deserialize<PullRequestReviewCommentEvent>(payout);
                        return;
                    case "PushEvent":
						PayloadObject = Client.Serializer.Deserialize<PushEvent>(payout);
                        return;
                    case "TeamAddEvent":
						PayloadObject = Client.Serializer.Deserialize<TeamAddEvent>(payout);
                        return;
                    case "WatchEvent":
						PayloadObject = Client.Serializer.Deserialize<WatchEvent>(payout);
                        return;
					case "ReleaseEvent":
						PayloadObject = Client.Serializer.Deserialize<ReleaseEvent>(payout);
						return;
                }
            } 
            catch
            {
            }
        }

		
		public class ReleaseEvent
		{
			public string Action { get; set; }
			public ReleaseModel Release { get; set; }
		}

        
        public class RepoModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
        }

        
        public class CommitCommentEvent
        {
            public CommentModel Comment { get; set; }
        }

        
        public class CreateEvent
        {
            public string RefType { get; set; }
            public string Ref { get; set; }
            public string MasterBranch { get; set; }
            public string Description { get; set; }
        }

        
        public class DeleteEvent
        {
            public string RefType { get; set; }
            public string Ref { get; set; }
        }

        
        public class DownloadEvent
        {
        }

        
        public class FollowEvent
        {
            public BasicUserModel Target { get; set; }
        }

        
        public class ForkEvent
        {
            public RepositoryModel Forkee { get; set; }
        }

        
        public class ForkApplyEvent
        {
            public string Head { get; set; }
            public string Before { get; set; }
            public string After { get; set; }
        }

        
        public class GistEvent
        {
            public string Action { get; set; }
            public GistModel Gist { get; set; }
        }

        
        public class GollumEvent
        {
            public List<PageModel> Pages { get; set; }

            
            public class PageModel
            {
                public string PageName { get; set; }
                public string Sha { get; set; }
                public string Title { get; set; }
                public string Action { get; set; }
                public string HtmlUrl { get; set; }
            }
        }

        
        public class IssueCommentEvent
        {
            public string Action { get; set; }
            public IssueModel Issue { get; set; }
            public CommentModel Comment { get; set; }
        }

        
        public class IssuesEvent
        {
            public string Action { get; set; }
            public IssueModel Issue { get; set; }
        }

        
        public class MemberEvent
        {
            public BasicUserModel Member { get; set; }
            public string Action { get; set; }
        }

        
        public class PublicEvent
        {
        }

        
        public class PullRequestEvent
        {
            public string Action { get; set; }
            public long Number { get; set; }
            public PullRequestModel PullRequest { get; set; }
        }

        
        public class PullRequestReviewCommentEvent
        {
            public CommentModel Comment { get; set; }
        }

        
        public class PushEvent
        {
            public string Before { get; set; }
            public string Ref { get; set; }
            public long Size { get; set; }
            public List<CommitModel> Commits { get; set; }

            
            public class CommitModel
            {
                public CommitAuthorModel Author { get; set; }
				public bool? Distinct { get; set; }
                public string Url { get; set; }
                public string Message { get; set; }
                public string Sha { get; set; }

                
                public class CommitAuthorModel
                {
                    public string Name { get; set; }
                    public string Email { get; set; }
                }
            }
        }

        
        public class TeamAddEvent
        {
            public TeamModel Team { get; set; }
            public BasicUserModel User { get; set; }
            public RepositoryModel Repo { get; set; }
        }

        
        public class WatchEvent
        {
            public string Action { get; set; }
        }
    }
}



