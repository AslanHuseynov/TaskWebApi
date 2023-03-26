namespace WebApiProject.Dtos.BookDto
{
    public class CreateBookDto : BaseBookDto
    {
        public List<int> AuthorIds { get; set; }
    }
}
