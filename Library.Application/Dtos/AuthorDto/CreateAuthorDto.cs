namespace Library.Application.Dtos.AuthorDto
{
    public class CreateAuthorDto : BaseAuthorDto
    {
        public List<int> BookIds { get; set; }
    }
}
