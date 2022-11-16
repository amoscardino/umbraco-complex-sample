using TMDbLib.Objects.Search;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace UmbracoComplexSample.Models;

public class MovieSearchModel : PublishedContentWrapped
{
    public string? Title { get; set; }
    public string? Body { get; set; }

    public MovieSearchFormModel SearchForm { get; set; }
    public List<SearchMovie> Results {get; set;}

    public MovieSearchModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
        : base(content, publishedValueFallback)
    {
        Title = content.Value<string>("title");
        Body = content.Value<string>("body");

        SearchForm = new MovieSearchFormModel();
        Results = new List<SearchMovie>();
    }
}
