namespace WebApiProject.Models
{
    public class Author : BusinessObject
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        
        public IList<Book> AuthorBooks { get; set; }
    }
}
