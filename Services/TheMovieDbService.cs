using TMDbLib.Client;
using TMDbLib.Objects.Search;

namespace UmbracoComplexSample.Services;

public class TheMovieDbService
{
    private readonly TMDbClient _tmdbClient;

    public TheMovieDbService(IConfiguration config)
    {
        _tmdbClient = new TMDbClient(config["TheMovieDb:ApiKey"]);
    }

    public async Task<List<SearchMovie>> SearchMoviesAsync(string searchTerm)
    {
        var config = await _tmdbClient.GetConfigAsync();
        var results = await _tmdbClient.SearchMovieAsync(searchTerm);

        foreach (var result in results.Results)
        {
            if (!string.IsNullOrWhiteSpace(result.PosterPath))
                result.PosterPath = config.Images.BaseUrl + config.Images.PosterSizes.Last() + result.PosterPath;
        }

        return results.Results;
    }

    public async Task<List<SearchTv>> SearchShowsAsync(string searchTerm)
    {
        var config = await _tmdbClient.GetConfigAsync();
        var results = await _tmdbClient.SearchTvShowAsync(searchTerm);

        foreach (var result in results.Results)
        {
            if (!string.IsNullOrWhiteSpace(result.PosterPath))
                result.PosterPath = config.Images.BaseUrl + config.Images.PosterSizes.Last() + result.PosterPath;
        }

        return results.Results;
    }
}