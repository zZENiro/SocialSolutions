using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class EventAlbum
    {
        [Key]
        public int Id { get; set; }

        public Event Event { get; set; }
        
        public string Name { get; set; }

        public IEnumerable<EventImage> Images { get; set; }
    }
}
