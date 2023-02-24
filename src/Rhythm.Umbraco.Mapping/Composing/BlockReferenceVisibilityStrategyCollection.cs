namespace Rhythm.Umbraco.Mapping.Composing;

using global::Umbraco.Cms.Core.Composing;
using Rhythm.Umbraco.Mapping.Strategies;
using System;
using System.Collections.Generic;

public sealed class BlockReferenceVisibilityStrategyCollection : BuilderCollectionBase<IBlockReferenceVisibilityStrategy>
{
	public BlockReferenceVisibilityStrategyCollection(Func<IEnumerable<IBlockReferenceVisibilityStrategy>> items) : base(items)
	{
	}
}