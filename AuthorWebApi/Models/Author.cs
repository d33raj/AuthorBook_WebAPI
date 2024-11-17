using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorWebApi.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }

        //navigation property 1-1
        public AuthorDetail? AuthorDetail { get; set; }

        [ForeignKey("AuthorDetail")]
        public int ADId { get; set; }

        //navigation property many part in 1-M relation
        public List<Book>? Book { get; set; }


    }
}
