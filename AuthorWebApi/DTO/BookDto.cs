using AuthorWebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorWebApi.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AId { get; set; }
    }
}
