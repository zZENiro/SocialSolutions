using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Models
{
    public class LocationsEvents
    {
        [Key]
        public int Id { get; set; }

        public Event Event { get; set; }

        public Location Location { get; set; }
    }
}
