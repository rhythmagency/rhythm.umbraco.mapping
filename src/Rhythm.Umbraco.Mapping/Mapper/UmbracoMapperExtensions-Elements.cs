namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Models.Common;
using System;
using System.Collections.Generic;

public static partial class UmbracoMapperExtensions
{
    public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this IUmbracoMapper mapper, IPublishedElement? item) 
    {
        return mapper.MapPageComponents(new[] { item });
    }

    public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this IUmbracoMapper mapper, IPublishedElement? item, IReadOnlyDictionary<string, object> context)
    {
        return mapper.MapPageComponents(new[] { item }, context);
    }

    public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this MapperContext mapperContext, IPublishedElement? item)
    {
        return mapperContext.MapPageComponents(new[] { item });
    }

    public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this MapperContext mapperContext, IPublishedElement? item, IReadOnlyDictionary<string, object> context)
    {
        return mapperContext.MapPageComponents(new[] { item }, context);
    }

    public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this IUmbracoMapper mapper, IReadOnlyCollection<IPublishedElement?>? items)
    {
        return MapPageComponents(mapper.MapOrDefault<IPageComponentModel?>, items);
    }

    public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this IUmbracoMapper mapper, IReadOnlyCollection<IPublishedElement?>? items, IReadOnlyDictionary<string, object> context)
    {
        return MapPageComponents((x) => { return mapper.MapOrDefault<IPageComponentModel?>(x, context); }, items);
    }

    public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this MapperContext mapperContext, IReadOnlyCollection<IPublishedElement?>? items)
    {
        return MapPageComponents(mapperContext.MapOrDefault<IPageComponentModel?>, items);
    }

    public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this MapperContext mapperContext, IReadOnlyCollection<IPublishedElement?>? items, IReadOnlyDictionary<string, object> context)
    {
        return MapPageComponents((x) => { return mapperContext.MapOrDefault<IPageComponentModel?>(x, context); }, items);
    }

    private static IReadOnlyCollection<IPageComponentModel> MapPageComponents(Func<IPublishedElement, IPageComponentModel?> func, IReadOnlyCollection<IPublishedElement?>? items)
    {
        if (items is null)
        {
            return Array.Empty<IPageComponentModel>();
        }

        var mappedComponents = new List<IPageComponentModel>();

        foreach (var item in items)
        {
            if (item is null)
            {
                continue;
            }

            var mappedComponent = func.Invoke(item);
            var handledMappedComponents = HandleMappedComponent(mappedComponent);

            mappedComponents.AddRange(handledMappedComponents);
        }

        return mappedComponents.ToArray();
    }
}