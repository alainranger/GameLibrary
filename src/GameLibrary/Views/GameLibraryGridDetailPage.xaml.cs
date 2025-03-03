using System.Windows.Controls;

using GameLibrary.ViewModels;

namespace GameLibrary.Views;

public partial class GameLibraryGridDetailPage : Page
{
    public GameLibraryGridDetailPage(GameLibraryGridDetailViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
