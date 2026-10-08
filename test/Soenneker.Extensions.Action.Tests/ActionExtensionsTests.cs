using AwesomeAssertions;
using Soenneker.Tests.Unit;
using System.Threading;

namespace Soenneker.Extensions.Action.Tests;

public class ActionExtensionsTests : UnitTest
{
    [Test]
    public async System.Threading.Tasks.ValueTask ToValueTask_InvokesActionAndCompletes(CancellationToken cancellationToken)
    {
        var invoked = false;
        System.Action action = () => invoked = true;

        System.Threading.Tasks.ValueTask result = action.ToValueTask();

        await result;
        invoked.Should().BeTrue();
    }
}
