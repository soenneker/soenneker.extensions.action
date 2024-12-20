using FluentAssertions;
using Soenneker.Tests.Unit;
using Xunit;

namespace Soenneker.Extensions.Action.Tests;

public class ActionExtensionsTests : UnitTest
{
    [Fact]
    public void Default()
    {
        true.Should().BeTrue();
    }
}
