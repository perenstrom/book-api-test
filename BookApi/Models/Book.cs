namespace BookApi.Models
{
    public class Book : Item
    {
        public int Author { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
    }
}
