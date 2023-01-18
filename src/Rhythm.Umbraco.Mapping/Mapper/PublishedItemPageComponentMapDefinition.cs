namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Umbraco.Mapping.Models;

/// <inheritdoc />
public abstract class PublishedItemPageComponentMapDefinition<TModel> : PublishedItemMapDefinition<TModel, IPageComponentModel>
    where TModel : IPublishedElement
{
    /// <inheritdoc />
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TModel, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
    }

    /// <summary>
    /// Returns a collection of <see cref="IPageComponentModel"/> objects.
    /// </summary>
    /// <param name="components">The mapped collection.</param>
    /// <returns>A <see cref="PageComponentCollection"/> which represents a collection of <see cref="IPageComponentModel"/>.</returns>
    protected IPageComponentModel Collection(IEnumerable<IPageComponentModel> components)
    {
        return new PageComponentCollection(components);
    }
}
