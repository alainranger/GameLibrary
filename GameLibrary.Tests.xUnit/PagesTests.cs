using System.IO;
using System.Reflection;

using GameLibrary.Contracts.Services;
using GameLibrary.Core.Contracts.Services;
using GameLibrary.Core.Services;
using GameLibrary.Models;
using GameLibrary.Services;
using GameLibrary.ViewModels;
using GameLibrary.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Xunit;

namespace GameLibrary.Tests.XUnit;

public class PagesTests
{
    private readonly IHost _host;

    public PagesTests()
    {
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => c.SetBasePath(appLocation))
            .ConfigureServices(ConfigureServices)
            .Build();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // Core Services
        services.AddSingleton<IFileService, FileService>();

        // Services
        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
        services.AddSingleton<ISystemService, SystemService>();
        services.AddSingleton<IDataService, SampleDataService>();
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        // ViewModels
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<GameLibraryGridViewModel>();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    // TODO: Add tests for functionality you add to SettingsViewModel.
    [Fact]
    public void TestSettingsViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(SettingsViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetSettingsPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(SettingsViewModel).FullName);
            Assert.Equal(typeof(SettingsPage), pageType);
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to MainViewModel.
    [Fact]
    public void TestMainViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(MainViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetMainPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(MainViewModel).FullName);
            Assert.Equal(typeof(MainPage), pageType);
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to GameLibraryGridViewModel.
    [Fact]
    public void TestGameLibraryGridViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(GameLibraryGridViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetGameLibraryGridPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(GameLibraryGridViewModel).FullName);
            Assert.Equal(typeof(GameLibraryGridPage), pageType);
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }
}
