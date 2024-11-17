using System.ComponentModel.DataAnnotations;

namespace AuthorWebApi.Models
{
    public class AuthorDetail
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        //navigation property 1-1 relation
        public Author? Author { get; set; }
    }
}
