namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.Blocks;

/// <summary>
/// Extension methods that augments the <see cref="IGetVisibleBlockReferences" /> interface.
/// </summary>
public static class GetVisibleBlockReferencesExtensions
{
	public static BlockListModel Execute(this IGetVisibleBlockReferences activity, BlockListModel? blocks)
	{
		var visibleBlocks = activity.Execute(blocks);

		return new BlockListModel(visibleBlocks.ToArray());
	}
}
