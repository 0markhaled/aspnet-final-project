using System.ComponentModel.DataAnnotations;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages;

public class AdoptModel : PageModel
{
    private readonly ILogger<AdoptModel> _logger;

    public List<Pet> adoptPets = default!;

    private ProjectContext listContext;

    [BindProperty]
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";

    [BindProperty]
    public Pet Pet { get; set; } = default!;

    [BindProperty]
    [Required]
    [MinLength(10), MaxLength(1000)]
    public string Message { get; set; } = "";

    // [BindProperty]
    // public AdoptPetFormModel AdoptForm { get; set; } = default!;

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
        SelectItems = new SelectList(adoptPets, nameof(Pet.PetId), nameof(Pet.Name));
        return Page();
    }

    public SelectList SelectItems { get; set; }


    public async Task<IActionResult> OnPostAsync()
    {
        // part of 4th step, loading pets from petsContext, putting into list
        adoptPets = await listContext.Pets.ToListAsync();
        _logger.LogInformation(Email);
        _logger.LogInformation(Message);
        _logger.LogInformation(Pet.ToString());

        if (Pet.PetId > 0)
        {
            FormSubmitted = true;
            var pet = await listContext.Pets.FindAsync(Pet.PetId);
            if (pet == null)
            {
                return BadRequest();

            }
            _logger.LogInformation(pet.ToString());
        }
        _logger.LogInformation(FormSubmitted.ToString());
        return Page();
    }
}