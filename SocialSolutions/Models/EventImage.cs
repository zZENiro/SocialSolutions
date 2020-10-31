using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class EventImage
    {
        [Key]
        public int Id { get; set; }

        public Image Image { get; set; }
    }
}
