namespace WebApiProject.Models
{
    public class Author2Book : BusinessObject
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
