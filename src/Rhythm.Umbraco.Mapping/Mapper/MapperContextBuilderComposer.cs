namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

public sealed class MapperContextBuilderComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddTransient<IMapperContextBuilderFactory, MapperContextBuilderFactory>();
    }
}
