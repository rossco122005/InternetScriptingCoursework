using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookMusicCompany.Data;
using ChinookMusicCompany.Models;

namespace ChinookMusicCompany.Pages.Albums
{
    public class DetailsModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public DetailsModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Albums
                .Include(a => a.Tracks)
                .Include(b => b.Artist)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AlbumID == id);

            if (Album == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
