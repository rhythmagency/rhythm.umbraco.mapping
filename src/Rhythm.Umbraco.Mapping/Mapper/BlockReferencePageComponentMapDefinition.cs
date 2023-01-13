namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;

/// <inheritdoc />
public abstract class BlockReferencePageComponentMapDefinition<TContent> : BlockReferenceMapDefinition<TContent, IPageComponentModel>
    where TContent : IPublishedElement
{
    /// <inheritdoc />
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TContent>, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
    }
}

/// <inheritdoc />
public abstract class BlockReferencePageComponentMapDefinition<TContent, TSettings> : BlockReferenceMapDefinition<TContent, TSettings, IPageComponentModel>
    where TContent : IPublishedElement
    where TSettings : IPublishedElement
{
    /// <inheritdoc />
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TContent, TSettings>, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
    }
}
