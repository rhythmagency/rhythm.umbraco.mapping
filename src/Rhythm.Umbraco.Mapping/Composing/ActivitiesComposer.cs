namespace Rhythm.Umbraco.Mapping.Composing;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Rhythm.Umbraco.Mapping.Activities;

/// <summary>
/// A composer which registers mapping activities.
/// </summary>
public sealed class ActivitiesComposer : IComposer
{
    /// <inheritdoc />
    public void Compose(IUmbracoBuilder builder)
	{
		builder.Services.AddTransient<ICheckBlockReferenceVisibility, CheckBlockReferenceVisibility>();
		builder.Services.AddTransient<IGetPageContent, GetPageContent>();
		builder.Services.AddTransient<IGetVisibleBlockReferences, GetVisibleBlockReferences>();
	}
}
