namespace CodeCamp.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public string DisplayName => $"{Name} ({Count})";

        public bool Selected { get; set; }

    }
}