namespace Rhythm.Umbraco.Mapping.MapDefinitions;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.Mapping;

/// <summary>
/// A contract for <see cref="IMapDefinition" /> implementations that are discoverable by the type loader by default.
/// </summary>
public interface IDiscoverableMapDefinition : IDiscoverable, IMapDefinition
{
}
