using System;
using System.Collections.Generic;

namespace ChinookMusicCompany.Models
{
    public class Track
    {
        public int TrackID {get; set;}
        public string Name {get; set;}
        public int AlbumID {get; set;}
        public Album Album {get; set;}
        public int MediaTypeID {get; set;}
        public MediaType MediaType {get; set;}
        public int GenreID {get; set;}
        public Genre Genre {get; set;}
        public string Composer {get; set;}
        public int Milliseconds {get; set;}
        public int Bytes {get; set;}
        public decimal UnitPrice {get; set;}
    }
}