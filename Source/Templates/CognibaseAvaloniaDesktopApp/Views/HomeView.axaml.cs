using Avalonia.Controls;
using CognibaseAvaloniaDesktopApp.ViewModels;
using Missionware.Cognibase.Library;
using Missionware.SharedLib.Avalonia;

namespace CognibaseAvaloniaDesktopApp.Views;

public partial class HomeView : UserControl
{
    private HomeViewModel _vm;
    public HomeView()
    {
        InitializeComponent();
    }

    public void Setup(IClient client, AvaloniaDialog dialog)
    {
        _vm = new HomeViewModel(client, dialog);
        DataContext = _vm;
    }
}
