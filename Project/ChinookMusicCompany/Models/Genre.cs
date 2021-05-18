using System;
using System.Collections.Generic;

namespace ChinookMusicCompany.Models
{
    public class Genre
    {
        public int GenreID {get; set;}
        public string Name {get; set;}
        public ICollection<Track> Tracks {get; set;}
    }
}