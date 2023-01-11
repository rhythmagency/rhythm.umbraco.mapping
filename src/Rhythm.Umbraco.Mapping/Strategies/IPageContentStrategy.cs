namespace Rhythm.Umbraco.Mapping.Strategies;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Patterns.Strategies;
using System.Collections.Generic;

/// <summary>
/// A general contract for creating page content strategies.
/// </summary>
/// <remarks>Implementations will typically use <see cref="Strategy{TInput, TOutput}"/>.</remarks>
public interface IPageContentStrategy : IStrategy<IPublishedContent, IReadOnlyCollection<IPageComponentModel>?>
{
}
