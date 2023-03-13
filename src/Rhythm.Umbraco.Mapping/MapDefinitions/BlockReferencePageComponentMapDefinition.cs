namespace Rhythm.Umbraco.Mapping.MapDefinitions;

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
        mapper.Define<BlockGridItem<TContent>, IPageComponentModel?>((block, mapperContext) => Map(block, mapperContext));
        mapper.Define<BlockListItem<TContent>, IPageComponentModel?>((block, mapperContext) => Map(block, mapperContext));
    }

    /// <summary>
    /// Allows this map definition to return multiple <see cref="IPageComponentModel"/> objects.
    /// </summary>
    /// <param name="components">The mapped collection.</param>
    /// <returns>A <see cref="PageComponentCollection"/> which represents a collection of <see cref="IPageComponentModel"/>.</returns>
    /// <remarks>Returned <see cref="IPageComponentModel"/> objects will be merged into the <see cref="IUmbracoMapper" /> MapPageComponents return value. These object will not be nested in a collection object.</remarks>
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
        mapper.Define<BlockGridItem<TContent, TSettings>, IPageComponentModel?>((block, mapperContext) => Map(block, mapperContext));
        mapper.Define<BlockListItem<TContent, TSettings>, IPageComponentModel?>((block, mapperContext) => Map(block, mapperContext));
    }

    /// <summary>
    /// Allows this map definition to return multiple <see cref="IPageComponentModel"/> objects.
    /// </summary>
    /// <param name="components">The mapped collection.</param>
    /// <returns>A <see cref="PageComponentCollection"/> which represents a collection of <see cref="IPageComponentModel"/>.</returns>
    /// <remarks>Returned <see cref="IPageComponentModel"/> objects will be merged into the <see cref="IUmbracoMapper" /> MapPageComponents return value. These object will not be nested in a collection object.</remarks>
    protected IPageComponentModel Collection(IEnumerable<IPageComponentModel> components)
    {
        return new PageComponentCollection(components);
    }
}
