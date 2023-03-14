namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using global::Umbraco.Extensions;
using System.Collections.Generic;
public static class MapperContextExtensions
{
    /// <summary>Get value or default from the <see cref="MapperContext"/> Items dictionary.</summary>
    /// <param name="context">The context.</param>
    /// <param name="itemKey">The item key.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <returns>The <see cref="TItem"/>.</returns>
    /// <remarks>This exists as a shorthand to accessing the MapperContext Items property.</remarks>
    public static TItem? GetItemValueOrDefault<TItem>(this MapperContext context, string itemKey, TItem? defaultValue = default)
    {
        if (context.Items.ContainsKey(itemKey) == false)
        {
            return defaultValue;
        }

        if (context.Items.TryGetValue(itemKey, out var output) == false)
        {
            return defaultValue;
        }

        if (output is TItem typedOutput)
        {
            return typedOutput;
        }

        var attempt = output.TryConvertTo<TItem?>();

        if (attempt.Success)
        {
            return attempt.Result;
        }

        if (output is null)
        {
            return defaultValue;
        }

        var attemptAsString = output.ToString().TryConvertTo<TItem?>();

        return attemptAsString.ResultOr(defaultValue);
    }

    /// <summary>
    /// Attempts to add items to the existing MapperContext Items dictionary.
    /// </summary>
    /// <param name="context">The current context.</param>
    /// <param name="dictionary">The new dictionary of items.</param>
    /// <returns>A <see cref="MapperContext"/>.</returns>
    public static MapperContext AddItems(this MapperContext context, IReadOnlyDictionary<string, object?> dictionary)
    {
        foreach (var kvp in dictionary)
        {
            context.Items.TryAdd(kvp.Key, kvp.Value);
        }

        return context;
    }

    /// <summary>
    /// Attempts to add an item to the existing MapperContext Items dictionary.
    /// </summary>
    /// <param name="context">The current context.</param>
    /// <param name="kvp">The new item.</param>
    /// <param name="behavior">The behavior used when attempting to add to the current dictionary.</param>
    /// <returns>A <see cref="MapperContext"/>.</returns>
    public static MapperContext AddItem(this MapperContext context, KeyValuePair<string, object?> kvp)
    {
        context.Items.TryAdd(kvp.Key, kvp.Value);

        return context;
    }

    /// <summary>
    /// Attempts to add an item to the existing MapperContext Items dictionary.
    /// </summary>
    /// <param name="context">The current context.</param>
    /// <param name="key">The new item key.</param>
    /// <param name="value">The new item value.</param>
    /// <returns>A <see cref="MapperContext"/>.</returns>
    public static MapperContext AddItem(this MapperContext context, string key, object? value)
    {
        context.Items.TryAdd(key, value);

        return context;
    }

    /// <summary>Gets the current page from the <see cref="MapperContext"/>.</summary>
    /// <param name="context">The current mapper context.</param>
    /// <returns>A <see cref="IPublishedContent" /> if one is available. Or null if one was not assigned to the mapper context.</returns>
    public static IPublishedContent? GetCurrentPage(this MapperContext context)
    {
        return context.GetItemValueOrDefault<IPublishedContent?>(MapperContextConstants.Keys.CurrentPage);
    }

    /// <summary>Gets the current page from the <see cref="MapperContext"/> as a given type.</summary>
    /// <param name="context">The current mapper context.</param>
    /// <typeparam name="TPublishedContent">The type of the current page.</typeparam>
    /// <returns>A <typeparamref name="TPublishedContent"/> if one is available. Or null if one was not assigned to the mapper context.</returns>
    public static TPublishedContent? GetCurrentPage<TPublishedContent>(this MapperContext context) where TPublishedContent : class, IPublishedElement
    {
        return context.GetCurrentPage() as TPublishedContent;
    }
}
