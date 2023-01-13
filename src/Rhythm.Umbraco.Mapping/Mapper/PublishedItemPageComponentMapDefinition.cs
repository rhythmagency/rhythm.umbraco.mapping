namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;

/// <inheritdoc />
public abstract class PublishedItemPageComponentMapDefinition<TModel> : PublishedItemMapDefinition<TModel, IPageComponentModel>
    where TModel : IPublishedElement
{
}
