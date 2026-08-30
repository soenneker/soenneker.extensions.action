using AwesomeAssertions;
using Soenneker.Tests.Unit;

namespace Soenneker.Extensions.Action.Tests;

public class ActionExtensionsTests : UnitTest
{
    [Test]
    public async System.Threading.Tasks.Task ToValueTask_InvokesActionAndCompletes()
    {
        var invoked = false;
        System.Action action = () => invoked = true;

        System.Threading.Tasks.ValueTask result = action.ToValueTask();

        await result;
        invoked.Should().BeTrue();
    }
}
