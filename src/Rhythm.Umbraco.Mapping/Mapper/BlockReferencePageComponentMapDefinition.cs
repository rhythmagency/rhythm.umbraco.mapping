namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;

/// <summary>
/// Maps a <see cref="IBlockReference"/> with a <typeparamref name="TContent"/>.
/// </summary>
/// <typeparam name="TContent">The type of the content.</typeparam>
/// <remarks>This map definition ignores the settings. Use the <see cref="BlockReferencePageComponentMapDefinition{TContent, TSettings}"/> if settings are needed.</remarks>
public abstract class BlockReferencePageComponentMapDefinition<TContent> : IDiscoverableMapDefinition
    where TContent : IPublishedElement
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TContent>, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
    }

    /// <summary>
    /// Maps the model to a <see cref="IPageComponentModel"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="mapperContext">The mapper context.</param>
    /// <returns>A <see cref="IPageComponentModel"/>.</returns>
    protected virtual IPageComponentModel? Map(BlockListItem<TContent> model, MapperContext mapperContext)
    {
        return Map(model.Content, mapperContext);
    }

    /// <inheritdoc />
    public abstract IPageComponentModel? Map(TContent content, MapperContext mapperContext);
}

/// <summary>
/// Maps a <see cref="IBlockReference"/> with a <typeparamref name="TContent"/> and <typeparamref name="TSettings"/>.
/// </summary>
/// <typeparam name="TContent">The type of the content.</typeparam>
/// <typeparam name="TSettings">The type of the settings.</typeparam>
/// <remarks>This map definition uses settings. Use the <see cref="BlockReferencePageComponentMapDefinition{TContent}"/> if settings are not needed.</remarks>
public abstract class BlockReferencePageComponentMapDefinition<TContent, TSettings> : IDiscoverableMapDefinition 
    where TContent : IPublishedElement
    where TSettings : IPublishedElement
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TContent, TSettings>, IPageComponentModel?>((block, mapperContext) => this.Map(block, mapperContext));
    }

    /// <summary>
    /// Maps the model to a <see cref="IPageComponentModel"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="mapperContext">The mapper context.</param>
    /// <returns>A <see cref="IPageComponentModel"/>.</returns>
    protected virtual IPageComponentModel? Map(BlockListItem<TContent, TSettings> model, MapperContext mapperContext)
    {
        return Map(model.Content, model.Settings, mapperContext);
    }

    /// <inheritdoc />
    public abstract IPageComponentModel? Map(TContent content, TSettings settings, MapperContext mapperContext);
}
