namespace Rhythm.Umbraco.Mapping.Models;

using Rhythm.Models.Common;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A internal model only used during the mapping process.
/// </summary>
/// <remarks>This is used to return multiple <see cref="IPageComponentModel"/> from a map definition.</remarks>
internal sealed class PageComponentCollection : IPageComponentModel, IHavePageComponents
{
    /// <summary>
    /// The components.
    /// </summary>
    private readonly IPageComponentModel[] _components;

    /// <summary>
    /// Initializes a new instance of the <see cref="PageComponentCollection"/> class.
    /// </summary>
    /// <param name="components">The components.</param>
    public PageComponentCollection(IEnumerable<IPageComponentModel> components)
    {
        _components = components.ToArray();
    }

    /// <inheritdoc />
    public IReadOnlyCollection<IPageComponentModel> GetPageComponents()
    {
        return _components;
    }
}
