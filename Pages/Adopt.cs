using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages;

public class AdoptModel : PageModel
{
    private readonly ILogger<AdoptModel> _logger;

    public AdoptModel(ILogger<AdoptModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}