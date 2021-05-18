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
    public class IndexModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public IndexModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; }

        public async Task OnGetAsync()
        {
            Album = await _context.Albums
            .Include(b => b.Artist)
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
