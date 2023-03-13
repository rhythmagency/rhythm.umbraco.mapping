namespace Rhythm.Umbraco.Mapping.Mapper;

/// <summary>
/// A concrete implementation of <see cref="IMapperContextBuilderFactory"/>.
/// </summary>
internal sealed class MapperContextBuilderFactory : IMapperContextBuilderFactory
{
    /// <inheritdoc />
    public IMapperContextBuilder Create()
    {
        return new MapperContextBuilder();
    }
}