namespace CodeCamp.Core.Models
{
    public class Tagsresult
    {
        public string tagName { get; set; }
        public bool taggedInSession { get; set; }
        public string sorter { get; set; }
        public int sessionId { get; set; }
        public int sessionsTaggedCount { get; set; }
        public string tagNameUrlFriendly { get; set; }
        public int id { get; set; }
        public string tagDescription { get; set; }
    }
}