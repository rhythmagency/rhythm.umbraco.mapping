namespace Rhythm.Umbraco.Mapping.Composing;

using global::Umbraco.Cms.Core.Composing;
using Rhythm.Umbraco.Mapping.Strategies;

/// <summary>
/// An order collection builder for registering <see cref="IBlockReferenceVisibilityStrategy"/> implementations.
/// </summary>
public sealed class BlockReferenceVisibilityStrategyCollectionBuilder : OrderedCollectionBuilderBase<BlockReferenceVisibilityStrategyCollectionBuilder, BlockReferenceVisibilityStrategyCollection, IBlockReferenceVisibilityStrategy>
{
    /// <inheritdoc />
    protected override BlockReferenceVisibilityStrategyCollectionBuilder This => this;
}
