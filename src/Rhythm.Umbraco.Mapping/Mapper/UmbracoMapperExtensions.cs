namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Models.Common;
using Rhythm.Umbraco.Mapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public static partial class UmbracoMapperExtensions
{
    public static TOutput? MapOrDefault<TInput, TOutput>(this IUmbracoMapper mapper, TInput? input)
    {
        return MapOrDefault(mapper.Map<TInput, TOutput>, input);
    }

    public static TOutput? MapOrDefault<TInput, TOutput>(this IUmbracoMapper mapper, TInput? input, IReadOnlyDictionary<string, object> context)
    {
        Func<TInput?, TOutput?> mapFunc = (item) =>
        {
            return mapper.Map<TInput?, TOutput?>(item, mapperContext =>
            {
                mapperContext.AddItems(context);
            });
        };

        return MapOrDefault(mapFunc, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TInput, TOutput>(this IUmbracoMapper mapper, IReadOnlyCollection<TInput?> input)
    {
        return MapCollectionOrEmpty(mapper.MapOrDefault<TInput?, TOutput?>, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TInput, TOutput>(this IUmbracoMapper mapper, IReadOnlyCollection<TInput?> input, IReadOnlyDictionary<string, object> context)
    {
        Func<TInput?, TOutput?> mapFunc = (item) =>
        {
            return mapper.Map<TInput?, TOutput?>(item, mapperContext =>
            {
                mapperContext.AddItems(context);
            });
        };

        return MapCollectionOrEmpty(mapFunc, input);
    }

    public static TOutput? MapOrDefault<TOutput>(this IUmbracoMapper mapper, object? input)
    {
        return MapOrDefault(mapper.Map<TOutput>, input);
    }

    public static TOutput? MapOrDefault<TOutput>(this IUmbracoMapper mapper, object? input, IReadOnlyDictionary<string, object> context)
    {
        Func<object?, TOutput?> mapFunc = (item) =>
        {
            return mapper.Map<TOutput?>(item, mapperContext =>
            {
                mapperContext.AddItems(context);
            });
        };

        return MapOrDefault(mapFunc, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TOutput>(this IUmbracoMapper mapper, IReadOnlyCollection<object?> input)
    {
        return MapCollectionOrEmpty(mapper.MapOrDefault<TOutput?>, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TOutput>(this IUmbracoMapper mapper, IReadOnlyCollection<object?> input, IReadOnlyDictionary<string, object> context)
    {
        Func<object?, TOutput?> mapFunc = (item) =>
        {
            return mapper.Map<TOutput?>(item, mapperContext =>
            {
                mapperContext.AddItems(context);
            });
        };

        return MapCollectionOrEmpty(mapFunc, input);
    }

    public static TOutput? MapFirstOrDefault<TInput, TOutput>(this IUmbracoMapper mapper, IReadOnlyCollection<TInput?> input)
    {
        return MapFirstOrDefault(mapper.Map<TInput, TOutput>, input);
    }

    public static TOutput? MapFirstOrDefault<TOutput>(this IUmbracoMapper mapper, IReadOnlyCollection<object?> input)
    {
        return MapFirstOrDefault(mapper.Map<TOutput>, input);
    }

    public static TOutput? MapOrDefault<TInput, TOutput>(this MapperContext mapperContext, TInput? input)
    {
        return MapOrDefault(mapperContext.Map<TInput, TOutput>, input);
    }

    public static TOutput? MapOrDefault<TInput, TOutput>(this MapperContext mapperContext, TInput? input, IReadOnlyDictionary<string, object> context)
    {
        Func<TInput?, TOutput?> mapFunc = (item) =>
        {
            mapperContext.AddItems(context);

            return mapperContext.Map<TOutput>(item);
        };

        return MapOrDefault(mapFunc, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TInput, TOutput>(this MapperContext mapperContext, IReadOnlyCollection<TInput?> input)
    {
        return MapCollectionOrEmpty(mapperContext.MapOrDefault<TInput?, TOutput>, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TInput, TOutput>(this MapperContext mapperContext, IReadOnlyCollection<TInput?> input, IReadOnlyDictionary<string, object> context)
    {
        Func<TInput?, TOutput?> mapFunc = (item) =>
        {
            mapperContext.AddItems(context);

            return mapperContext.Map<TOutput>(item);
        };

        return MapCollectionOrEmpty(mapFunc, input);
    }

    public static TOutput? MapFirstOrDefault<TInput, TOutput>(this MapperContext mapperContext, IReadOnlyCollection<TInput?> input)
    {
        return MapFirstOrDefault(mapperContext.Map<TInput, TOutput>, input);
    }

    public static TOutput? MapFirstOrDefault<TOutput>(this MapperContext mapperContext, IReadOnlyCollection<object?> input)
    {
        return MapFirstOrDefault(mapperContext.Map<TOutput>, input);
    }


    public static TOutput? MapOrDefault<TOutput>(this MapperContext mapperContext, object? input)
    {
        return MapOrDefault(mapperContext.Map<TOutput>, input);
    }

    public static TOutput? MapOrDefault<TOutput>(this MapperContext mapperContext, object? input, IReadOnlyDictionary<string, object> context)
    {
        Func<object?, TOutput?> mapFunc = (item) =>
        {
            mapperContext.AddItems(context);

            return mapperContext.Map<TOutput>(item);
        };

        return MapOrDefault(mapFunc, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TOutput>(this MapperContext mapperContext, IReadOnlyCollection<object?> input)
    {
        return MapCollectionOrEmpty(mapperContext.MapOrDefault<TOutput>, input);
    }

    public static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TOutput>(this MapperContext mapperContext, IReadOnlyCollection<object?> input, IReadOnlyDictionary<string, object> context)
    {
        Func<object?, TOutput?> mapFunc = (item) =>
        {
            mapperContext.AddItems(context);
            return mapperContext.Map<TOutput?>(item);
        };

        return MapCollectionOrEmpty(mapFunc, input);
    }

    private static IReadOnlyCollection<TOutput> MapCollectionOrEmpty<TInput, TOutput>(Func<TInput?, TOutput?> func, IReadOnlyCollection<TInput?> items)
    {
        if (items is null)
        {
            return Array.Empty<TOutput>();
        }

        var mappedItems = new List<TOutput>();

        foreach (var item in items)
        {
            if (item is null)
            {
                continue;
            }

            var mappedItem = func.Invoke(item);

            if (mappedItem is not null)
            {
                mappedItems.Add(mappedItem);
            }
        }

        return mappedItems.ToArray();
    }

    private static TOutput? MapFirstOrDefault<TInput, TOutput>(Func<TInput?, TOutput?> func, IReadOnlyCollection<TInput?> input)
    {
        if (input is null)
        {
            return default;
        }

        var firstInput = input.FirstOrDefault();

        return MapOrDefault(func, firstInput);
    }

    private static TOutput? MapOrDefault<TInput, TOutput>(Func<TInput?, TOutput?> func, TInput? input)
    {
        if (input is null)
        {
            return default;
        }

        return func.Invoke(input);
    }

    private static IReadOnlyCollection<IPageComponentModel> HandleMappedComponent(IPageComponentModel? component)
    {
        if (component is null)
        {
            return Array.Empty<IPageComponentModel>();
        }

        var collection = new List<IPageComponentModel>();

        if (component is not PageComponentCollection)
        {
            collection.Add(component);
        }

        if (component is IHavePageComponents components)
        {
            collection.AddRange(components.GetPageComponents());
        }

        return collection.ToArray();
    }
}
