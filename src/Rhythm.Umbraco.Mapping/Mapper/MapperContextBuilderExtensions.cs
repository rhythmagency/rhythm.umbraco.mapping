namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Models.PublishedContent;

public static class MapperContextBuilderExtensions
{
    /// <summary>
    /// Adds a current page value to a <see cref="IMapperContextBuilderWithOneOrMoreValues" />.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <param name="content">The content.</param>
    /// <returns>A <see cref="IMapperContextBuilderWithOneOrMoreValues" />.</returns>
    public static IMapperContextBuilderWithOneOrMoreValues AndCurrentPage(this IMapperContextBuilderWithOneOrMoreValues builder, IPublishedContent content)
    {
        return builder.AndValue(MapperContextConstants.Keys.CurrentPage, content);
    }

    /// <summary>
    /// Adds a current page value to a <see cref="IMapperContextBuilder" />.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <param name="content">The content.</param>
    /// <returns></returns>
    public static IMapperContextBuilderWithOneOrMoreValues WithCurrentPage(this IMapperContextBuilder builder, IPublishedContent content)
    {
        return builder.WithValue(MapperContextConstants.Keys.CurrentPage, content);
    }
}
