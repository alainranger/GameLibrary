using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using GameLibrary.Contracts.Services;
using GameLibrary.Contracts.ViewModels;
using GameLibrary.Core.Contracts.Services;
using GameLibrary.Core.Models;

namespace GameLibrary.ViewModels;

public class GameLibraryGridViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _sampleDataService;
    private ICommand _navigateToDetailCommand;

    public ICommand NavigateToDetailCommand => _navigateToDetailCommand ??= new RelayCommand<Game>(NavigateToDetail);

    public ObservableCollection<Game> Source { get; } = new ObservableCollection<Game>();

    public GameLibraryGridViewModel(IDataService sampleDataService, INavigationService navigationService)
    {
        _sampleDataService = sampleDataService;
        _navigationService = navigationService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // Replace this with your actual data
        var data = await _sampleDataService.GetGamesAsync();
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    private void NavigateToDetail(Game game)
    {
        _navigationService.NavigateTo(typeof(GameLibraryGridDetailViewModel).FullName, game.Id);
    }
}
