namespace WebApiProject.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
