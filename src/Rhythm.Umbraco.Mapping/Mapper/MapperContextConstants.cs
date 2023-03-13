namespace Rhythm.Umbraco.Mapping.Mapper;

using global::Umbraco.Cms.Core.Mapping;

/// <summary>
/// Internally used constants for <see cref="MapperContext" />.
/// </summary>
public static class MapperContextConstants
{
    /// <summary>
    /// Keys used for accessing specific MapperContext data.
    /// </summary>
    public static class Keys
    {
        /// <summary>
        /// The Current Page key.
        /// </summary>
        public const string CurrentPage = nameof(CurrentPage);
    }
}