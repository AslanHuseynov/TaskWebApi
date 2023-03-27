namespace Library.Application.Dtos.BookDto
{
    public class BaseBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public DateTime CreateDate { get; set; }
        public string Image { get; set; }
    }
}
