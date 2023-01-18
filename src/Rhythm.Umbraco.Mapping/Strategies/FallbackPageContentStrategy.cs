namespace Rhythm.Umbraco.Mapping.Strategies;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Patterns.Strategies;
using System.Collections.Generic;

/// <summary>
/// A fallback page content strategy.
/// </summary>
public sealed class FallbackPageContentStrategy : Strategy<IPublishedElement, IReadOnlyCollection<IPageComponentModel>>, IPageContentStrategy
{
    /// <inheritdoc />
    protected override IReadOnlyCollection<IPageComponentModel>? Execute(IPublishedElement? input)
    {
        return Array.Empty<IPageComponentModel>();
    }

    /// <inheritdoc />
    protected override bool ValidateInput(IPublishedElement? input)
    {
        return true;
    }
}
