using System;
using System.Collections.Generic;

namespace ChinookMusicCompany.Models
{
    public class Album
    {
        public int AlbumID {get; set;}
        public string Title {get; set;}

        public int ArtistID{get; set;}
        public Artist Artist{get; set;}

        public ICollection<Track> Tracks {get; set;}
    }
}