namespace Rhythm.Umbraco.Mapping.Strategies;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Patterns.Strategies;
using System.Collections.Generic;

/// <summary>
/// An abstract implementation of <see cref="IPageContentStrategy"/> which works for a specific implementation of <see cref="IPublishedElement"/>.
/// </summary>
/// <typeparam name="TPublishedItem">The type of published content or element.</typeparam>
/// <remarks>This class uses <see cref="IPublishedElement"/> over <see cref="IPublishedContent"/> for content type composition support.</remarks>
public abstract class PageContentStrategy<TPublishedItem> : Strategy<IPublishedElement, IReadOnlyCollection<IPageComponentModel>?>, IPageContentStrategy where TPublishedItem : class, IPublishedElement
{
    /// <inheritdoc />
    protected override bool ValidateInput(IPublishedElement? input)
    {
        return input is TPublishedItem;
    }

    /// <inheritdoc />
    protected sealed override IReadOnlyCollection<IPageComponentModel>? Execute(IPublishedElement input)
    {
        if (input is not TPublishedItem content)
        {
            return EmptyCollection();
        }

        return Execute(content);
    }

    /// <summary>
    /// Converts a <typeparamref name="TPublishedItem"/> to a <see cref="IReadOnlyCollection{IPageComponentModel}" />.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A readonly collection of <see cref="IPageComponentModel"/>.</returns>
    protected abstract IReadOnlyCollection<IPageComponentModel>? Execute(TPublishedItem input);

    /// <summary>
    /// Gets an empty page component collection.
    /// </summary>
    /// <returns>An empty page component collection.</returns>
    protected IReadOnlyCollection<IPageComponentModel>? EmptyCollection()
    {
        return Array.Empty<IPageComponentModel>();
    }
}
