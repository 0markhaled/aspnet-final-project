using System.ComponentModel.DataAnnotations;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages;

public class AdoptModel : PageModel
{
    private readonly ILogger<AdoptModel> _logger;

    public List<Pet> adoptPets = default!;

    private ProjectContext listContext;

    public class AdoptPetFormModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";

        public uint PetId { get; set; } = 0;

        [Required]
        [MinLength(10), MaxLength(1000)]
        public string Message { get; set; } = "";
    }

    [BindProperty(SupportsGet = true)]
    public AdoptPetFormModel AdoptForm { get; set; } = null;

    public AdoptModel(ILogger<AdoptModel> logger, ProjectContext context)
    {
        listContext = context; // added this step 3
        _logger = logger;
    }

    public bool FormSubmitted { get; set; } = false;

    public async Task<IActionResult> OnGetAsync()
    {
        // part of 4th step, loading pets from petsContext, putting into list
        adoptPets = await listContext.Pets.ToListAsync();

        if (AdoptForm != null)
        {
            FormSubmitted = true;
            // can do something here
            // can make a db context for inserting message here
        }

        return Page();
    }
}