using System.Windows.Controls;

using GameLibrary.ViewModels;

namespace GameLibrary.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
