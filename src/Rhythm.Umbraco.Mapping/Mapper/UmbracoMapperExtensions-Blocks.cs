namespace Rhythm.Umbraco.Mapping.Mapper
{
    using global::Umbraco.Cms.Core.Mapping;
    using global::Umbraco.Cms.Core.Models.Blocks;
    using global::Umbraco.Cms.Core.Models.PublishedContent;
    using Rhythm.Models.Common;
    using System;
    using System.Collections.Generic;

    public static partial class UmbracoMapperExtensions
    {
        public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block)
        {
            return mapper.MapPageComponents(new[] { block });
        }

        public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, IReadOnlyDictionary<string, object?> context)
        {
            return mapper.MapPageComponents(new[] { block }, context);
        }

        public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block)
        {
            return mapperContext.MapPageComponents(new[] { block });
        }

        public static IReadOnlyCollection<IPageComponentModel> MapPageComponent(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block, IReadOnlyDictionary<string, object?> context)
        {
            return mapperContext.MapPageComponents(new[] { block }, context);
        }

        public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this IUmbracoMapper mapper, IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>?>? blocks)
        {
            return MapPageComponents(mapper.MapOrDefault<IPageComponentModel>, blocks);
        }

        public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this IUmbracoMapper mapper, IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>?>? blocks, IReadOnlyDictionary<string, object?> context)
        {
            return MapPageComponents((x) => { return mapper.MapOrDefault<IPageComponentModel>(x, context); }, blocks);
        }

        public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this MapperContext mapperContext, IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>?>? blocks)
        {
            return MapPageComponents(mapperContext.MapOrDefault<IPageComponentModel>, blocks);
        }

        public static IReadOnlyCollection<IPageComponentModel> MapPageComponents(this MapperContext mapperContext, IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>?>? blocks, IReadOnlyDictionary<string, object?> context)
        {
            return MapPageComponents((x) => { return mapperContext.MapOrDefault<IPageComponentModel>(x, context); }, blocks);
        }

        private static IReadOnlyCollection<IPageComponentModel> MapPageComponents(Func<IBlockReference<IPublishedElement, IPublishedElement>, IPageComponentModel?> func, IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>?>? blocks)
        {
            if (blocks is null)
            {
                return Array.Empty<IPageComponentModel>();
            }

            var mappedBlocks = new List<IPageComponentModel>();

            foreach (var block in blocks)
            {
                if (block is null)
                {
                    continue;
                }

                var mappedBlock = func.Invoke(block);
                var handledMappedComponents = HandleMappedComponent(mappedBlock);

                mappedBlocks.AddRange(handledMappedComponents);
            }

            return mappedBlocks.ToArray();
        }
    }
}
