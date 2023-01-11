namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Patterns.Strategies;
using Rhythm.Umbraco.Mapping.Composing;
using System.Collections.Generic;

/// <summary>
/// An implementation of <see cref="IGetPageContent" /> which uses content strategies.
/// </summary>
public sealed class GetPageContent : IGetPageContent
{
    private readonly PageContentStrategyCollection _strategies;

    public GetPageContent(PageContentStrategyCollection strategies)
    {
        _strategies = strategies;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<IPageComponentModel> Execute(IPublishedContent input)
    {
        var components = new List<IPageComponentModel>();
        var results = _strategies.ExecuteMultiple(input);

        return results.SelectMany(x => x).ToArray();
    }
}
