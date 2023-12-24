using Missionware.Cognibase.Library;
using ReactiveUI;
using System.Threading.Tasks;
using System;
using Missionware.SharedLib.UI;

namespace CognibaseAvaloniaDesktopApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    IClient _client;
    private readonly IAsyncDialogService _dialogService;

    public string Greeting => "Welcome to Cognibase!";

    public MainViewModel() { }

    public MainViewModel(IClient client, IAsyncDialogService dialogService)
    {
        _client = client;
        _dialogService = dialogService;
    }
}


