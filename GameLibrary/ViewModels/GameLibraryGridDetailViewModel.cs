using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using GameLibrary.Contracts.ViewModels;
using GameLibrary.Core.Contracts.Services;
using GameLibrary.Core.Models;

namespace GameLibrary.ViewModels;

public class GameLibraryGridDetailViewModel : ObservableObject, INavigationAware
{
    private readonly IDataService _sampleDataService;
    private Game _item;

    public Game Item
    {
        get { return _item; }
        set { SetProperty(ref _item, value); }
    }

    public GameLibraryGridDetailViewModel(IDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is Guid gameId)
        {
            var data = await _sampleDataService.GetGamesAsync();
            Item = data.First(i => i.Id == gameId);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
