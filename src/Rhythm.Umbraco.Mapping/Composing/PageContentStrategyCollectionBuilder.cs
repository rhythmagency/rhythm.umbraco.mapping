namespace Rhythm.Umbraco.Mapping.Composing;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using global::Umbraco.Cms.Core.Composing;
using Rhythm.Umbraco.Mapping.Strategies;

/// <summary>
/// An order collection builder for registering <see cref="IPageContentStrategy"/> implementations.
/// </summary>
/// <remarks>
/// <para>
/// The order is important as it determines the order of the content on the page.
/// </para>
/// <para>
/// An <see cref="IPublishedContent" /> could match multiple <see cref="IPageContentStrategy" /> implementations.
/// </para>
/// <para>
/// For example, and a page header strategy should be executed before the main content strategy.
/// </para>
/// </remarks>
public sealed class PageContentStrategyCollectionBuilder : OrderedCollectionBuilderBase<PageContentStrategyCollectionBuilder, PageContentStrategyCollection, IPageContentStrategy>
{
    /// <inheritdoc />
    protected override PageContentStrategyCollectionBuilder This => this;
}
