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

namespace ChinookMusicCompany.Pages.Tracks
{
    public class EditModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public EditModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.Tracks
                .Include(t => t.Album)
                .Include(t => t.Genre)
                .Include(t => t.MediaType).FirstOrDefaultAsync(m => m.TrackID == id);

            if (Track == null)
            {
                return NotFound();
            }
           ViewData["AlbumID"] = new SelectList(_context.Albums, "AlbumID", "Title");
           ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "Name");
           ViewData["MediaTypeID"] = new SelectList(_context.Set<MediaType>(), "MediaTypeID", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(Track.TrackID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackID == id);
        }
    }
}
