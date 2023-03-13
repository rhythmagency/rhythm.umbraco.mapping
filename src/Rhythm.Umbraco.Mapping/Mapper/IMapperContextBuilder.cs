namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;

/// <summary>
/// A contract for creating an empty <see cref="IMapperContextBuilder" />.
/// </summary>
public interface IMapperContextBuilder
{
    /// <summary>
    /// Adds a value to the current <see cref="IMapperContextBuilder" />.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>A <seealso cref="IMapperContextBuilderWithOneOrMoreValues" />.</returns>
    IMapperContextBuilderWithOneOrMoreValues WithValue(string key, object? value);

    /// <summary>
    /// Adds values from an existing MapperContext.
    /// </summary>
    /// <param name="mapperContext">The mapper context.</param>
    /// <returns>A <see cref="IMapperContextBuilderWithOneOrMoreValues" />.</returns>
    IMapperContextBuilderWithOneOrMoreValues FromExisting(MapperContext mapperContext);
}