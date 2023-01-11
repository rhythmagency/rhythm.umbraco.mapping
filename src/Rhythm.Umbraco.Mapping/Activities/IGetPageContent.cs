namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Patterns.Activities;
using System.Collections.Generic;

/// <summary>
/// A contract to create an activity to get page content for a <see cref="IPublishedContent" />.
/// </summary>
public interface IGetPageContent : IActivity<IPublishedContent, IReadOnlyCollection<IPageComponentModel>> 
{
}
