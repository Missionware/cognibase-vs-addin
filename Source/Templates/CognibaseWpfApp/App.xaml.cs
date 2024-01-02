using Missionware.Cognibase.Client;
using Missionware.Cognibase.Security.Identity.Domain.System;
using Missionware.Cognibase.UI.Wpf.Client;
using Missionware.Cognibase.UI.Wpf.Dialogs;
using Missionware.Cognibase.UI.Wpf.Extensions;
using Missionware.SharedLib;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CognibaseWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // On Startup
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //
            // WPF APPLICATION BUILDUP
            //
            CognibaseWpfApp.MainWindow.App = WpfApplicationBuilder.CreateAsMain(this)
                .WithMainWindowType<MainWindow>()
                .WithAuthenticationWindowType<DefaultAuthenticateWindow>()
                .WithMainClient(o =>
                    ClientBuilder<WpfApplication>.CreateFor(o)
                        .WithSettingsFromConfig()
                        // here add you domain factory registration statement
                        .WithDomainFactory<IdentityFactory>()
                        .Build())
                .Build();

            // Start a splash screen
            CognibaseWpfApp.MainWindow.App.StartSplash(new SplashControlData
            {
                ImageBytes =
                    new BitmapImage(new Uri("pack://application:,,,/Images/cognibase_splash.png"))
                        .ToImageBytes(),
                MessageColorCode = new AppColor { A = 255, R = 255, G = 255, B = 255 },
                TitleMessage = "Initializing App..."
            });

            // Start
            CognibaseWpfApp.MainWindow.App.StartUpClient(StartupConnectionMode.StartAndConnect);
        }
    }
}
