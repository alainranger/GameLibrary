using System.Windows.Controls;

using GameLibrary.ViewModels;

namespace GameLibrary.Views;

public partial class GameLibraryGridPage : Page
{
    public GameLibraryGridPage(GameLibraryGridViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
