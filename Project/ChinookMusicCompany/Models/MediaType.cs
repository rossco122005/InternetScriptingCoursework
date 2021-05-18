using System;
using System.Collections.Generic;

namespace ChinookMusicCompany.Models
{
    public class MediaType
    {
        public int MediaTypeID {get; set;}
        public string Name {get; set;}
        public ICollection<Track> Tracks {get; set;}
    }
}