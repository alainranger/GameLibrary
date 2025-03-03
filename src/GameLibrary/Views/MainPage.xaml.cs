using System.Windows.Controls;

using GameLibrary.ViewModels;

namespace GameLibrary.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
