using GameLibrary.Core.Services;

using Xunit;

namespace GameLibrary.Core.Tests.XUnit;

public class SampleDataServiceTests
{
    public SampleDataServiceTests()
    {
    }

    // Remove or update this once your app is using real data and not the SampleDataService.
    // This test serves only as a demonstration of testing functionality in the Core library.
    [Fact]
    public async Task EnsureSampleDataServiceReturnsContentGridDataAsync()
    {
        var sampleDataService = new SampleDataService();

        var data = await sampleDataService.GetGamesAsync();

        Assert.True(data.Any());
    }
}
