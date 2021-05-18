using ChinookMusicCompany.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChinookMusicCompany.Pages.Albums
{
    public class ArtistNamePageModel : PageModel
    {
        public SelectList ArtistNameSL { get; set; }

        public void PopulateArtistsDropDownList(ShopContext _context,
            object selectedArtist = null)
        {
            var artistsQuery = from d in _context.Artists
                                   orderby d.Name // Sort by name.
                                   select d;

            ArtistNameSL = new SelectList(artistsQuery.AsNoTracking(),
                        "ArtistID", "Name", selectedArtist);
        }
    }
}