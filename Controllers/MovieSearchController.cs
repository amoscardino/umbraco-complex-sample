using Microsoft.AspNetCore.Mvc;
using UmbracoComplexSample.Models;
using UmbracoComplexSample.Services;

namespace UmbracoComplexSample.Controllers;

public class MovieSearchController : BaseController
{
    private readonly TheMovieDbService _tmdbService;

    public MovieSearchController(IServiceProvider serviceProvider, TheMovieDbService tmdbService)
        : base(serviceProvider)
    {
        _tmdbService = tmdbService;
    }

    public async Task<IActionResult> MovieSearchAsync(MovieSearchFormModel? model = null)
    {
        var vm = new MovieSearchModel(CurrentPage!, PublishedValueFallback)
        {
            SearchForm = model ?? new MovieSearchFormModel()
        };

        if (!string.IsNullOrWhiteSpace(vm.SearchForm.SearchTerm))
            vm.Results = await _tmdbService.SearchMoviesAsync(vm.SearchForm.SearchTerm);

        return CurrentTemplate(vm);
    }
}