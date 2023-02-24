namespace Rhythm.Umbraco.Mapping.Strategies;

using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Patterns.Strategies;

public interface IBlockReferenceVisibilityStrategy : IStrategy<IBlockReference<IPublishedElement, IPublishedElement>, bool>
{
}
