using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace UmbracoComplexSample.Controllers;

public class BaseSurfaceController : SurfaceController
{
    public BaseSurfaceController(IServiceProvider serviceProvider)
        : base(
            serviceProvider.GetRequiredService<IUmbracoContextAccessor>(),
            serviceProvider.GetRequiredService<IUmbracoDatabaseFactory>(),
            serviceProvider.GetRequiredService<ServiceContext>(),
            serviceProvider.GetRequiredService<AppCaches>(),
            serviceProvider.GetRequiredService<IProfilingLogger>(),
            serviceProvider.GetRequiredService<IPublishedUrlProvider>()
        )
    { }
}
