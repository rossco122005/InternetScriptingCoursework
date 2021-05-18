using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookMusicCompany.Data;
using ChinookMusicCompany.Models;

namespace ChinookMusicCompany.Pages.Artists
{
    public class DeleteModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public DeleteModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists.FirstOrDefaultAsync(m => m.ArtistID == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists.FindAsync(id);

            if (Artist != null)
            {
                _context.Artists.Remove(Artist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
