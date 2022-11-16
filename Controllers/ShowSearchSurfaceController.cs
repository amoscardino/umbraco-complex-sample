using Microsoft.AspNetCore.Mvc;
using UmbracoComplexSample.Models;
using UmbracoComplexSample.Services;

namespace UmbracoComplexSample.Controllers;

public class ShowSearchSurfaceController : BaseSurfaceController
{
    private readonly TheMovieDbService _tmdbService;

    public ShowSearchSurfaceController(IServiceProvider serviceProvider, TheMovieDbService tmdbService)
        : base(serviceProvider)
    {
        _tmdbService = tmdbService;
    }

    public async Task<IActionResult> SearchAsync(ShowSearchFormModel model)
    {
        var results = await _tmdbService.SearchShowsAsync(model.SearchTerm ?? "");

        return PartialView("_ShowSearchResults", results);
    }
}
