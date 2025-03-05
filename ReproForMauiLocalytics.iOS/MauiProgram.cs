using Foundation;
using LocalyticsMaui.iOS;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;

namespace ReproForMauiLocalytics.iOS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseSharedMauiApp();

		builder.Services.AddSingleton<IPlatform, IosLocalyticsMaui>();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
