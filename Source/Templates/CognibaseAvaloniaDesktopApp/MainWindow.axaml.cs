using Avalonia.Controls;
using Avalonia.Threading;
using CognibaseAvaloniaDesktopApp.ViewModels;
using Missionware.Cognibase.Client;
using Missionware.Cognibase.Config;
using Missionware.Cognibase.Security.Identity.Domain.System;
using Missionware.Cognibase.UI.Avalonia;
using Missionware.Cognibase.UI.Common.ViewModels;
using Missionware.ConfigLib;
using Missionware.SharedLib;
using Missionware.SharedLib.Avalonia;
using System;

namespace CognibaseAvaloniaDesktopApp;

public partial class MainWindow : Window
{
    // static instance of the App
    public static AvaloniaApplication MyApp { get; set; }

    // initialize startup helper for Avalonia and dialog service
    private AvaloniaStartupHelper _startupHelper;
    private readonly AvaloniaDialog _dialog = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnInitialized()
    {
        // Call base
        base.OnInitialized();

        // Read client settings
        SettingsManager settings = ConfigBuilder.Create().FromAppConfigFile();

        // Get proper SECTION
        ClientSetupSettings clientSettings = settings.GetSection<ClientSetupSettings>();

        // Set to CUSTOM Connect Workflow
        clientSettings.ProcessSecuritySetting.UseCustomWorkflowToConnectSetting = true;

        // Initialize the correct (Avalonia) COGNIBASE Application through the Application Manager 
        MyApp = ApplicationManager.InitializeAsMainApplication(
            new AvaloniaApplication(new AvaloniaApplicationFeatures()));

        // Initializes a Client Object Manager with the settings from configuration
        var client = ClientObjMgr.Initialize(MyApp, ref clientSettings);

        // Registers domains through Domain Factory classes
        _ = client.RegisterDomainFactory<IdentityFactory>();
        // TODO: add your domain registration here

        // Initialize Security PROFILE
        _ = MyApp.InitializeApplicationSecurity(client, ref clientSettings);

        // set the main app window
        ApplicationManager.MainAppWindow = this;

        // Fix for Avalonia
        ApplicationManager.RegisterProcessInteractionModeProvider(() => { return  ProcessInteractionMode.Window; });

        // set sync context
        MyApp.RegisterMainSynchronizationContext();
    }

    protected override void OnClosed(EventArgs e)
    {
        // call base and close connection
        base.OnClosed(e);
        MyApp.Client.CloseConnection();
    }

    protected override async void OnOpened(EventArgs e)
    {
        // call base
        base.OnOpened(e);

        // build the startup helper that contains the auth manager, the auth dialog and the loader
        _startupHelper = new AvaloniaStartupHelper(this, MyApp.Client);
        _startupHelper.AuthVm = new SimpleAuthDialogVm { DomainFullName = "Basic", Username = "user1", Password = "user1" };
        _startupHelper.QuitAction = () => Close(); // set the quit action
        _startupHelper.DataLoadAction = () =>
        {
            // data initialization flow
            // read initial data that you need using a live collection
            //DataItemCollection<MyEntity> items = MyApp.Client.ReadDataItemCollection<MyEntity>();

            // set data source in main Avalonia thread
            Dispatcher.UIThread.Invoke(() =>
            {
                // do some initialization in the UI
                // maybe call the home view setup
                homeView.Setup(MyApp.Client, _dialog);
            });
        };

        // show the authentication dialog
        await _startupHelper.ShowAuthDialog().ConfigureAwait(false);
    }
}
