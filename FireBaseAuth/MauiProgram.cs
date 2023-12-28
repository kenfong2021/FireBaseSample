using DevExpress.Maui;
using DevExpress.Maui.Core;
using FireBaseAuth.Pages;
using FireBaseAuth.Services;
using FireBaseAuth.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace FireBaseAuth
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            ThemeManager.ApplyThemeToSystemBars = true;
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress(useLocalization: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                });

            // Add Service
            builder.Services.AddSingleton<IAuthService, AuthService>();
            // Add Views
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<AuthPage>();
            // Add ViewModel
            builder.Services.AddSingleton<AuthViewModel>();
            return builder.Build();
        }
    }
}
