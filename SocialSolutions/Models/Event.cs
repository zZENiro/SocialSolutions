using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
    
        public User Creator { get; set; }

        public User Moderator { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public IEnumerable<EventAlbum> EventAlbums { get; set; }

        public IEnumerable<HobbiesEvents> HobbiesEvents { get; set; }

        public IEnumerable<UsersEvents> UsersEvents { get; set; }

        public Location Location { get; set; }

        public bool IsFree { get; set; }
    }
}
