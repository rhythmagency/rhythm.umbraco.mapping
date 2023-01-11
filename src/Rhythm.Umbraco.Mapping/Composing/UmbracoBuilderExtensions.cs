namespace Rhythm.Umbraco.Mapping.Composing;

using global::Umbraco.Cms.Core.DependencyInjection;

public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Gets the page content strategy collection builder.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>A <see cref="PageContentStrategyCollectionBuilder"/>.</returns>
    public static PageContentStrategyCollectionBuilder PageContentStrategies(this IUmbracoBuilder builder)
        => builder.WithCollectionBuilder<PageContentStrategyCollectionBuilder>();
}