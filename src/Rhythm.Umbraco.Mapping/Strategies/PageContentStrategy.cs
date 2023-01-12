namespace Rhythm.Umbraco.Mapping.Strategies;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using Rhythm.Patterns.Strategies;
using System.Collections.Generic;

/// <summary>
/// An abstract implementation of <see cref="IPageContentStrategy"/> which works for a specific implementation of <see cref="IPublishedContent"/>.
/// </summary>
/// <typeparam name="TPublishedContent"></typeparam>
public abstract class PageContentStrategy<TPublishedContent> : Strategy<IPublishedContent, IReadOnlyCollection<IPageComponentModel>?>, IPageContentStrategy where TPublishedContent : class, IPublishedContent
{
    /// <inheritdoc />
    protected override bool ValidateInput(IPublishedContent? input)
    {
        return input is TPublishedContent;
    }

    /// <inheritdoc />
    protected sealed override IReadOnlyCollection<IPageComponentModel>? Execute(IPublishedContent? input)
    {
        if (input is not TPublishedContent content)
        {
            return Array.Empty<IPageComponentModel>();
        }

        return Execute(content);
    }

    /// <summary>
    /// Converts a <typeparamref name="TPublishedContent"/> to a <see cref="IReadOnlyCollection{IPageComponentModel}" />.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A readonly collection of <see cref="IPageComponentModel"/>.</returns>
    protected abstract IReadOnlyCollection<IPageComponentModel>? Execute(TPublishedContent input);
}
