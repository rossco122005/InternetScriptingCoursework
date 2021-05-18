using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChinookMusicCompany.Data;
using ChinookMusicCompany.Models;

namespace ChinookMusicCompany.Pages.Albums
{
    public class EditModel : ArtistNamePageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public EditModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Albums
                .Include(c => c.Artist).FirstOrDefaultAsync(m => m.AlbumID == id);

            if (Album == null)
            {
                return NotFound();
            }

            PopulateArtistsDropDownList(_context, Album.ArtistID);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var albumToUpdate = await _context.Albums.FindAsync(id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Album>(
                 albumToUpdate,
                 "album",   // Prefix for form value.
                   c => c.Title, c => c.ArtistID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select Album if TryUpdateModelAsync fails.
            PopulateArtistsDropDownList(_context, albumToUpdate.ArtistID);
            return Page();
            
            //Original
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(Album.AlbumID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
            */
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumID == id);
        }
    }
}
