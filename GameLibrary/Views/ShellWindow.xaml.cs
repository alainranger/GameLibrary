using System.Windows.Controls;

using GameLibrary.Contracts.Views;
using GameLibrary.ViewModels;

using MahApps.Metro.Controls;

namespace GameLibrary.Views;

public partial class ShellWindow : MetroWindow, IShellWindow
{
    public ShellWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    public Frame GetNavigationFrame()
        => shellFrame;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();
}
