namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Umbraco.Mapping.Models;

/// <inheritdoc />
public abstract class BlockReferencePageComponentMapDefinition<TContent> : BlockReferenceMapDefinition<TContent, IPageComponentModel>
    where TContent : IPublishedElement
{
    /// <inheritdoc />
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TContent>, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
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

/// <inheritdoc />
public abstract class BlockReferencePageComponentMapDefinition<TContent, TSettings> : BlockReferenceMapDefinition<TContent, TSettings, IPageComponentModel>
    where TContent : IPublishedElement
    where TSettings : IPublishedElement
{
    /// <inheritdoc />
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockGridItem<TContent, TSettings>, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
        mapper.Define<BlockListItem<TContent, TSettings>, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
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
