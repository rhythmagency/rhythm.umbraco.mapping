namespace Rhythm.Umbraco.Mapping.Activities;

using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using System.Collections.Generic;

internal sealed class GetVisibleBlockReferences : IGetVisibleBlockReferences
{
	private readonly ICheckBlockReferenceVisibility _checkBlockReferenceVisibility;

	public GetVisibleBlockReferences(ICheckBlockReferenceVisibility checkBlockReferenceVisibility)
	{
		_checkBlockReferenceVisibility = checkBlockReferenceVisibility;
	}

	public IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>> Execute(IReadOnlyCollection<IBlockReference<IPublishedElement, IPublishedElement>>? input)
	{
		var items = new List<IBlockReference<IPublishedElement, IPublishedElement>>();

		if (input is null)
		{
			return items;
		}

		foreach (var item in input)
		{
			if (_checkBlockReferenceVisibility.Execute(item))
			{
				items.Add(item);
			}
		}

		return items;
	}
}