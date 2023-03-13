namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/// <summary>
/// A concrete implementation of <see cref="IMapperContextBuilder" />.
/// </summary>
internal sealed class MapperContextBuilder : IMapperContextBuilder, IMapperContextBuilderWithOneOrMoreValues
{
    /// <summary>
    /// The internal collection of values.
    /// </summary>
    private readonly IDictionary<string, object?> _values = new Dictionary<string, object?>();

    /// <inheritdoc />
    public IMapperContextBuilderWithOneOrMoreValues WithValue(string key, object? value)
    {
        AddValue(key, value);

        return this;
    }

    /// <inheritdoc />
    public IMapperContextBuilderWithOneOrMoreValues AndValue(string key, object? value)
    {
        AddValue(key, value);

        return this;
    }

    /// <inheritdoc />
    public ReadOnlyMapperContext Build()
    {
        return new ReadOnlyMapperContext(_values);
    }

    public IMapperContextBuilderWithOneOrMoreValues FromExisting(MapperContext mapperContext)
    {
        foreach (var kvp in mapperContext.Items)
        {
            _values.Add(kvp);
        }

        return this;
    }

    private void AddValue(string key, object? value)
    {
        if (_values.ContainsKey(key))
        {
            _values[key] = value;
        }
        else
        {
            _values.Add(key, value);
        }
    }
}
