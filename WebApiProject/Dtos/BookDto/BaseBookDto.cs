namespace WebApiProject.Dtos.BookDto
{
    public class BaseBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
