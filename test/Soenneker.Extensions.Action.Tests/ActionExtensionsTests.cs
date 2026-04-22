using AwesomeAssertions;
using Soenneker.Tests.Unit;

namespace Soenneker.Extensions.Action.Tests;

public class ActionExtensionsTests : UnitTest
{
    [Test]
    public void Default()
    {
        true.Should().BeTrue();
    }
}
