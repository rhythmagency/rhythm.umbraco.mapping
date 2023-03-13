namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// A readonly context to pass data through to a <see cref="IUmbracoMapper"/> or <see cref="MapperContext"/>.
/// </summary>
/// <remarks>This class does not inherit from <see cref="MapperContext"/>.</remarks>
public sealed class ReadOnlyMapperContext : IReadOnlyDictionary<string, object?>
{
    private readonly IReadOnlyDictionary<string, object?> _dictionary;

    internal ReadOnlyMapperContext(IDictionary<string, object?> dictionary)
    {
        _dictionary = new ReadOnlyDictionary<string, object?>(dictionary);
    }

    internal ReadOnlyMapperContext(MapperContext context) : this(context.Items)
    {
    }

    public object? this[string key] => _dictionary[key];

    public IEnumerable<string> Keys => _dictionary.Keys;

    public IEnumerable<object?> Values => _dictionary.Values;

    public int Count => _dictionary.Count;

    public bool ContainsKey(string key)
    {
        return _dictionary.ContainsKey(key);
    }

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out object? value)
    {
        return _dictionary.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
