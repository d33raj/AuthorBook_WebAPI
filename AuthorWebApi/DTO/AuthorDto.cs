using AuthorWebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorWebApi.DTO
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public int TotalBooks { get; set; }
        public int ADId { get; set; }
    }
}
