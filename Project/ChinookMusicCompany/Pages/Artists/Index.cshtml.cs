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
    public class IndexModel : PageModel
    {
        private readonly ChinookMusicCompany.Data.ShopContext _context;

        public IndexModel(ChinookMusicCompany.Data.ShopContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; }

        public async Task OnGetAsync()
        {
            Artist = await _context.Artists.ToListAsync();
        }
    }
}
