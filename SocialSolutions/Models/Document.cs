using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
    
        public string Url { get; set; }

        public User Owner { get; set; }
    }
}
