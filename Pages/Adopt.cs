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

    // public class AdoptPetFormModel
    // {

    // }

    [BindProperty]
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";

    [BindProperty]
    public uint PetId { get; set; } = default!;

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

        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        // part of 4th step, loading pets from petsContext, putting into list
        adoptPets = await listContext.Pets.ToListAsync();
        _logger.LogInformation(Email);
        _logger.LogInformation(Message);
        _logger.LogInformation(PetId.ToString());
        //uint pId = uint.Parse(PetId);
        // if (PetId > 0)
        // {
        //     FormSubmitted = true;
        //     // can do something here
        //     // can make a db context for inserting message here
        // }
        _logger.LogInformation(FormSubmitted.ToString());
        return Page();
    }
}