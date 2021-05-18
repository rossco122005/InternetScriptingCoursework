using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinookMusicCompany.Data;
using ChinookMusicCompany.Models;

namespace ChinookMusicCompany.Pages.Tracks
{
    public class DetailsModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public DetailsModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
