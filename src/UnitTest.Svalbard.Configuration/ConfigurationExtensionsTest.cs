using Microsoft.Extensions.Configuration;
using Svalbard.Configuration;

namespace UnitTest.Svalbard.Configuration;

public class ConfigurationExtensionsTest
{
    private readonly IConfiguration _configuration;

    public ConfigurationExtensionsTest()
    {
        // Arrange
        _configuration = new ConfigurationBuilder()
            .AddJsonFile($"{nameof(ConfigurationExtensionsTest)}.json", false)
            .Build();
    }

    [Fact]
    public void BindingToMissingOptionalSectionShouldYieldNull()
    {
        // Act
        var foo = _configuration.GetAs<ConfTypeA>();

        // Asert
        Assert.Null(foo);
    }

    [Fact]
    public void BindingToPresentOptionalSectionShouldNotYieldNull()
    {
        // Act
        var foo = _configuration.GetAs<ConfTypeB>();

        // Asert
        Assert.NotNull(foo);
        Assert.Equal("bar", foo.Name);
    }

}

public class ConfTypeA
{
    public string? Name { get; set; }
}

public class ConfTypeB
{
    public string? Name { get; set; }
}
