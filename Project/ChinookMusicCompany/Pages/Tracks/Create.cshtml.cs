using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChinookMusicCompany.Data;
using ChinookMusicCompany.Models;

namespace ChinookMusicCompany.Pages.Tracks
{
    public class CreateModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public CreateModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AlbumID"] = new SelectList(_context.Albums, "AlbumID", "Title");
        ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "Name");
        ViewData["MediaTypeID"] = new SelectList(_context.Set<MediaType>(), "MediaTypeID", "Name");
            return Page();
        }

        [BindProperty]
        public Track Track { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tracks.Add(Track);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
