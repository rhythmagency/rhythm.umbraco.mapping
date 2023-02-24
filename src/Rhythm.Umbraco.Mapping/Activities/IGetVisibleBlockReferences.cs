namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Patterns.Activities;
using System.Collections.Generic;

public interface IGetVisibleBlockReferences : IActivity<IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>>?, IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>>>
{
}
