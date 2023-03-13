namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;

/// <summary>
/// A contract which represents a <see cref="IMapperContextBuilder" /> with at least one value.
/// </summary>
public interface IMapperContextBuilderWithOneOrMoreValues
{
    /// <summary>
    /// Adds another value to a <see cref="IMapperContextBuilder" />.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    IMapperContextBuilderWithOneOrMoreValues AndValue(string key, object? value);

    /// <summary>
    /// Builds a context ready to be used by a <see cref="IUmbracoMapper"/> or <see cref="MapperContext"/>.
    /// </summary>
    /// <returns>A read only context of values.</returns>
    ReadOnlyMapperContext Build();
}
