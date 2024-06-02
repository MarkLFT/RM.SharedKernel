using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ardalis.SharedKernel.UnitTests.GuidGeneratorTest;
public class GenerateSequentialGuids
{

  [Fact]
  public async Task GeneratesSequentialGuids()
  {
    // Arrange

    var services = new ServiceCollection();

    services.RegisterSequentialGuidGenerator();

    var serviceProvider = services.BuildServiceProvider();

    var sequentialGuidGenerator = serviceProvider.GetRequiredService<ISequentialGuidGenerator>();


    // Act

    var guid1 = sequentialGuidGenerator.NewSequentialGuid();

    /// Add 1ms delay as accuracy of Linux clock is 1ms, less that this, and they would have the same time.  
    /// Even if have the same time, they will not clash, they would not be guaranteed to be saved in the 
    /// correct sequence, becuase of the random part of the Guid.

    await Task.Delay(1);

    var guid2 = sequentialGuidGenerator.NewSequentialGuid();

    await Task.Delay(1);

    var guid3 = sequentialGuidGenerator.NewSequentialGuid();


    // Assert

    /// To sort in the same order as as SQL Server sort by, we need to compare the last 6 bytes of the Guid.
    var s1 = guid1.ToString().Substring(24);
    var s2 = guid2.ToString().Substring(24);
    var s3 = guid3.ToString().Substring(24);

    s1.CompareTo(s2).Should().BeLessThan(0);
    s2.CompareTo(s3).Should().BeLessThan(0);

  }
}

