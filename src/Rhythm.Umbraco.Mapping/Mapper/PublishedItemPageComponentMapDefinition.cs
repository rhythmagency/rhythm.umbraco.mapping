namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;

/// <inheritdoc />
public abstract class PublishedItemPageComponentMapDefinition<TModel> : PublishedItemMapDefinition<TModel, IPageComponentModel>
    where TModel : IPublishedElement
{
    /// <inheritdoc />
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TModel, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
    }
}
