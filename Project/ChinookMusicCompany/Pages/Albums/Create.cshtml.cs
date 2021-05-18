using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChinookMusicCompany.Data;
using ChinookMusicCompany.Models;

namespace ChinookMusicCompany.Pages.Albums
{
    public class CreateModel : ArtistNamePageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public CreateModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateArtistsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyAlbum = new Album();

            if (await TryUpdateModelAsync<Album>(
                 emptyAlbum,
                 "album",   // Prefix for form value.
                 s => s.Title, s => s.ArtistID))
            {
                _context.Albums.Add(emptyAlbum);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select AlbumID if TryUpdateModelAsync fails.
            PopulateArtistsDropDownList(_context, emptyAlbum.ArtistID);
            return Page();
        }
        
    }
}
