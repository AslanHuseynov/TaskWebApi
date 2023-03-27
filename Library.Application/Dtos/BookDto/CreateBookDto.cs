namespace Library.Application.Dtos.BookDto
{
    public class CreateBookDto : BaseBookDto
    {
        public List<int> AuthorIds { get; set; }
    }
}
