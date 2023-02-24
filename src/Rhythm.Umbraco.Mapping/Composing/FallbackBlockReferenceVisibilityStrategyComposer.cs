namespace Rhythm.Umbraco.Mapping.Composing;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.DependencyInjection;
using Rhythm.Umbraco.Mapping.Strategies;

/// <summary>
/// Registers a fallback <see cref="IPageContentStrategy"/>.
/// </summary>
public sealed class FallbackBlockReferenceVisibilityStrategyComposer : IComposer
{
    /// <inheritdoc />
    public void Compose(IUmbracoBuilder builder)
    {
        builder.BlockReferenceVisibilityStrategies().Append<FallbackBlockReferenceVisibilityStrategy>();
    }
}
