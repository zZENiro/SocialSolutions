using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
    
        public byte[] Data { get; set; }
    }
}
