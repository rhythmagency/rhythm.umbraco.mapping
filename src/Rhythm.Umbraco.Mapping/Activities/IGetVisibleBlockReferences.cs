namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using System.Collections.Generic;

public interface IGetVisibleBlockReferences
{
	IReadOnlyCollection<TReference> Execute<TReference>(IReadOnlyCollection<TReference>? input) where TReference : IBlockReference<IPublishedElement, IPublishedElement>;
}
