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
    public class DeleteModel : PageModel
    {
        private readonly Final_Project.Models.ProjectContext _context;

        public DeleteModel(Final_Project.Models.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets.FirstOrDefaultAsync(m => m.PetId == id);

            if (pet == null)
            {
                return NotFound();
            }
            else 
            {
                Pet = pet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(uint? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }
            var pet = await _context.Pets.FindAsync(id);

            if (pet != null)
            {
                Pet = pet;
                _context.Pets.Remove(Pet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
