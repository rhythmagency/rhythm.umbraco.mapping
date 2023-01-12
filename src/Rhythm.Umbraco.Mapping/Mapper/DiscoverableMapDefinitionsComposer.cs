namespace Rhythm.Umbraco.Mapping.Mapper
{
    using global::Umbraco.Cms.Core.Composing;
    using global::Umbraco.Cms.Core.DependencyInjection;
    
    /// <summary>
    /// A composer to register any <see cref="IDiscoverableMapDefinition"/> implementations.
    /// </summary>
    public sealed class DiscoverableMapDefinitionsComposer : IComposer
    {
        /// <inheritdoc />
        public void Compose(IUmbracoBuilder builder)
        {
            builder.MapDefinitions().Add(builder.TypeLoader.GetTypes<IDiscoverableMapDefinition>());
        }
    }
}
