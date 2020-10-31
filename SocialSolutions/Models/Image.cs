using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public byte[] Value { get; set; }
    }
}
