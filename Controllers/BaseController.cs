using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoComplexSample.Controllers;

public class BaseController : RenderController
{
    protected PublishedValueFallback PublishedValueFallback { get; }

    public BaseController(IServiceProvider serviceProvider)
        : base(
            serviceProvider.GetRequiredService<ILogger<RenderController>>(),
            serviceProvider.GetRequiredService<ICompositeViewEngine>(),
            serviceProvider.GetRequiredService<IUmbracoContextAccessor>()
        )
    {
        var serviceContext = serviceProvider.GetRequiredService<ServiceContext>();
        var variationContextAccessor = serviceProvider.GetRequiredService<IVariationContextAccessor>();

        PublishedValueFallback = new PublishedValueFallback(serviceContext, variationContextAccessor);
    }
}
