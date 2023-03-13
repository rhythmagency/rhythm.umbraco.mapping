namespace Rhythm.Umbraco.Mapping.MapDefinitions;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.PublishedContent;

/// <summary>
/// A map definition to map a <typeparamref name="TModel"/> a <typeparamref name="TOutput"/>.
/// </summary>
/// <typeparam name="TModel">The type of the published item.</typeparam>
/// <remarks>This supports <see cref="IPublishedContent" /> or <see cref="IPublishedElement" />.</remarks>
public abstract class PublishedItemMapDefinition<TModel, TOutput> : IDiscoverableMapDefinition where TModel : IPublishedElement
{
    /// <inheritdoc />
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {            
        mapper.Define<TModel, TOutput?>((model, mapperContext) => Map(model, mapperContext));
    }

    /// <summary>
    /// Maps a <typeparamref name="TModel"/> to a <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="mapperContext">The mapper context.</param>
    /// <returns>A <typeparamref name="TOutput"/>.</returns>
    public abstract TOutput? Map(TModel model, MapperContext mapperContext);
}
