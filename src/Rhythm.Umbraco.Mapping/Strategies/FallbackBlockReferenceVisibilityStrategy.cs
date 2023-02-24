namespace Rhythm.Umbraco.Mapping.Strategies;

using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Patterns.Strategies;

/// <summary>
/// A fallback page content strategy.
/// </summary>
public sealed class FallbackBlockReferenceVisibilityStrategy : Strategy<IBlockReference<IPublishedElement, IPublishedElement>, bool>, IBlockReferenceVisibilityStrategy
{
	/// <inheritdoc />
	protected override bool Execute(IBlockReference<IPublishedElement, IPublishedElement> input)
	{
		return true;
	}

	/// <inheritdoc />
	protected override bool ValidateInput(IBlockReference<IPublishedElement, IPublishedElement>? input)
	{
		return true;
	}
}
