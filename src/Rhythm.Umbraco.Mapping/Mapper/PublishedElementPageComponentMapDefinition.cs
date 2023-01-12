namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;

/// <summary>
/// A map definition to map a <typeparamref name="TModel"/> a <see cref="IPageComponentModel?"/>.
/// </summary>
/// <typeparam name="TModel">The type of the published item.</typeparam>
/// <remarks>This supports <see cref="IPublishedContent" /> or <see cref="IPublishedElement" />.</remarks>
public abstract class PublishedItemPageComponentMapDefinition<TModel> : IDiscoverableMapDefinition where TModel : IPublishedElement
{
    /// <inheritdoc />
    public void DefineMaps(IUmbracoMapper mapper)
    {            
        mapper.Define<TModel, IPageComponentModel?>((model, mapperContext) => Map(model, mapperContext));
    }

    /// <summary>
    /// Maps a <typeparamref name="TModel"/> to a <see cref="IPageComponentModel?"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="mapperContext">The mapper context.</param>
    /// <returns>A <see cref="IPageComponentModel?"/>.</returns>
    protected abstract IPageComponentModel? Map(TModel model, MapperContext mapperContext);
}
