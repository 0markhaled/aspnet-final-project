using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Pages_Pets
{
    public class IndexModel : PageModel
    {
        private readonly Final_Project.Models.ProjectContext _context;

        public IndexModel(Final_Project.Models.ProjectContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pets != null)
            {
                Pet = await _context.Pets.ToListAsync();
            }
        }
    }
}
