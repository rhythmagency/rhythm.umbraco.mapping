namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;

/// <summary>
/// Maps a <see cref="IBlockReference"/> with a <typeparamref name="TContent"/>.
/// </summary>
/// <typeparam name="TContent">The type of the content.</typeparam>
/// <typeparam name="TOutput">THe type of the output.</typeparam>
/// <remarks>This map definition ignores the settings. Use the <see cref="BlockReferenceMapDefinition{TContent, TSettings, TOutput}"/> if settings are needed.</remarks>
public abstract class BlockReferenceMapDefinition<TContent, TOutput> : IDiscoverableMapDefinition
    where TContent : IPublishedElement
{
    /// <inheritdoc />
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TContent>, TOutput?>((block, mapperContext) => this.Map(block, mapperContext));
    }

    /// <summary>
    /// Maps the model to a <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="mapperContext">The mapper context.</param>
    /// <returns>A <typeparamref name="TOutput"/>.</returns>
    protected virtual TOutput? Map(BlockListItem<TContent> model, MapperContext mapperContext)
    {
        return Map(model.Content, mapperContext);
    }

    /// <inheritdoc />
    public abstract TOutput? Map(TContent content, MapperContext mapperContext);
}

/// <summary>
/// Maps a <see cref="IBlockReference"/> with a <typeparamref name="TContent"/> and <typeparamref name="TSettings"/>.
/// </summary>
/// <typeparam name="TContent">The type of the content.</typeparam>
/// <typeparam name="TSettings">The type of the settings.</typeparam>
/// <typeparam name="TOutput">THe type of the output.</typeparam>
/// <remarks>This map definition uses settings. Use the <see cref="BlockReferenceMapDefinition{TContent, TOutput}"/> if settings are not needed.</remarks>
public abstract class BlockReferenceMapDefinition<TContent, TSettings, TOutput> : IDiscoverableMapDefinition 
    where TContent : IPublishedElement
    where TSettings : IPublishedElement
{
    /// <inheritdoc />
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TContent, TSettings>, TOutput?>((block, mapperContext) => this.Map(block, mapperContext));
    }

    /// <summary>
    /// Maps the model to a <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="mapperContext">The mapper context.</param>
    /// <returns>A <typeparamref name="TOutput"/>.</returns>
    protected virtual TOutput? Map(BlockListItem<TContent, TSettings> model, MapperContext mapperContext)
    {
        return Map(model.Content, model.Settings, mapperContext);
    }

    /// <inheritdoc />
    public abstract TOutput? Map(TContent content, TSettings settings, MapperContext mapperContext);
}
