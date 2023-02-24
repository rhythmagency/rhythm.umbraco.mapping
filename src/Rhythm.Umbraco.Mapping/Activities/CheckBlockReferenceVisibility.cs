namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Umbraco.Mapping.Composing;

internal sealed class CheckBlockReferenceVisibility : ICheckBlockReferenceVisibility
{
	private readonly BlockReferenceVisibilityStrategyCollection _strategies;

	public CheckBlockReferenceVisibility(BlockReferenceVisibilityStrategyCollection strategies)
	{
		_strategies = strategies;
	}

	public bool Execute(IBlockReference<IPublishedElement, IPublishedElement> input)
	{
		foreach (var strategy in _strategies)
		{
			var attempt = strategy.TryExecute(input);

			if (attempt.IsSuccessful && attempt.Output == false)
			{
				return false;
			}
		}

		return true;
	}
}
