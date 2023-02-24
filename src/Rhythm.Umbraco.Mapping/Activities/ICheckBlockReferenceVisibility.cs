namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Patterns.Activities;

public interface ICheckBlockReferenceVisibility : IActivity<IBlockReference<IPublishedElement, IPublishedElement>, bool>
{
}
