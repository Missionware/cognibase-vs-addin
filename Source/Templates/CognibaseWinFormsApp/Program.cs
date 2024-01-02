using CognibaseWinFormsApp.Properties;
using Missionware.Cognibase.Client;
using Missionware.Cognibase.Security.Identity.Domain.System;
using Missionware.Cognibase.UI.WinForms.Client;
using Missionware.SharedLib;
using Missionware.SharedLib.Drawing.Extensions;

namespace CognibaseWinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            //
            // WIN FORMS APPLICATION BUILDUP
            //
            MainForm.App = WinFormsApplicationBuilder.CreateAsMain()
                .WithMainWindowType<MainForm>()
                .WithMainClient(o =>
                    ClientBuilder.CreateFor(o)
                        .WithSettingsFromConfig()
                        // here add the domain factory for your domain
                        .WithDomainFactory<IdentityFactory>()
                        .Build())
                .Build();

            // Start a splash screen
            MainForm.App.StartSplash(new SplashControlData
            {
                ImageBytes = Resources.cognibase_splash.ToImageBytes(),
                MessageColorCode = new AppColor
                {
                    A = 255,
                    R = 255,
                    G = 255,
                    B = 255
                },
                TitleMessage = "Initializing App..."
            });

            // Start
            MainForm.App.StartUpClient(StartupConnectionMode.StartAndConnect);
        }
    }
}