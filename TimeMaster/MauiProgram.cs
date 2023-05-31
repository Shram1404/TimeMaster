using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TimeMaster.Data;
using TimeMaster.Program;

namespace TimeMaster;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSingleton<Firewall>(provider =>
        {
            var parameter = "dayzlag"; // Ваш параметр
            return new Firewall(parameter);
        });


        return builder.Build();
	}
}
