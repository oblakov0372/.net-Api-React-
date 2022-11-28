namespace BookProject.Resource.Api.Models.Book
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
