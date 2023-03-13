namespace Rhythm.Umbraco.Mapping.Mapper;

/// <summary>
/// A contract for creating a new <see cref="IMapperContextBuilder" />.
/// </summary>
public interface IMapperContextBuilderFactory
{
    /// <summary>
    /// Create a new <see cref="IMapperContextBuilder" />.
    /// </summary>
    /// <returns>A <see cref="IMapperContextBuilder"/>.</returns>
    IMapperContextBuilder Create();
}
