using System.Text.Json.Serialization;

namespace Library.Domain.Models
{
    public class Author2Book : BusinessObject
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
    }
}
