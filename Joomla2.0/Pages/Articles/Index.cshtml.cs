﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Joomla2._0.Data;
using Joomla2._0.Models;

namespace Joomla2._0.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly Joomla2._0.Data.ApplicationDbContext _context;

        public IndexModel(Joomla2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Article = await _context.Articles
                .Include(a => a.Author).ToListAsync();
        }
    }
}
