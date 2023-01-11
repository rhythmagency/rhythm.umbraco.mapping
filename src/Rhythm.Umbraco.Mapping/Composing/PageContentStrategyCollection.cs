namespace Rhythm.Umbraco.Mapping.Composing;

using global::Umbraco.Cms.Core.Composing;
using Rhythm.Umbraco.Mapping.Strategies;
using System;
using System.Collections.Generic;

/// <summary>
/// A collection to register <see cref="IPageContentStrategy" /> implementations.
/// </summary>
public sealed class PageContentStrategyCollection : BuilderCollectionBase<IPageContentStrategy>
{
    public PageContentStrategyCollection(Func<IEnumerable<IPageContentStrategy>> items) : base(items)
    {
    }
}
