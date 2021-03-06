﻿using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SocialSolutions.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public IEnumerable<LocationsEvents> LocationsEvents { get; set; }
    }
}
