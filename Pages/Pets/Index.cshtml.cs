using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Pages.Pets
{
    public class IndexModel : PageModel
    {
        private readonly ProjectContext _context;

        public IndexModel(ProjectContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string Query { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public DateTime? PetBirthday { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public bool? BeforePetBirthday { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public bool DateSearchEnable { get; set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<Pet> pets;
            if (Query != null)
            {
                pets = _context.Pets.Where(p => p.PetType.Contains(Query));
            }
            else
            {
                pets = _context.Pets;
            }

            if (PetBirthday != null && DateSearchEnable)
            {

                if (BeforePetBirthday != null)
                {
                    if (BeforePetBirthday.Value)
                    {
                        pets = pets.Where(g => g.Birthday <= PetBirthday);
                    }
                    else
                    {
                        pets = pets.Where(g => g.Birthday > PetBirthday);
                    }
                }

            }
            Pet = await pets.ToListAsync();
            Page();
        }
    }
}