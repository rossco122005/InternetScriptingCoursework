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
    public class IndexModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public IndexModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        public IList<Track> Track { get;set; }

        public async Task OnGetAsync()
        {
            Track = await _context.Tracks
                .Include(t => t.Album)
                .Include(t => t.Genre)
                .Include(t => t.MediaType).ToListAsync();
        }
    }
}
