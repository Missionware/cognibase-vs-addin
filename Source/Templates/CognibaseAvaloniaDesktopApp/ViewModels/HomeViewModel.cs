using Missionware.Cognibase.Library;
using ReactiveUI;
using System.Threading.Tasks;
using System;
using Missionware.SharedLib.UI;

namespace CognibaseAvaloniaDesktopApp.ViewModels;

public class HomeViewModel : ViewModelBase
{
    IClient _client;
    private readonly IAsyncDialogService _dialogService;

    public string Greeting => "Welcome to Cognibase!";

    public HomeViewModel() { }

    public HomeViewModel(IClient client, IAsyncDialogService dialogService)
    {
        _client = client;
        _dialogService = dialogService;
    }
}


