using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Extensions.Action;

/// <summary>
/// A collection of helpful Action extension methods
/// </summary>
public static class ActionExtensions
{
    /// <summary>
    /// Equivalent to <code>new Task(action)</code>
    /// </summary>
    public static Task ToTask(this System.Action action)
    {
        return new Task(action);
    }

    /// <summary>
    /// Equivalent to <code>Task.Run(action)</code>
    /// </summary>
    public static Task RunAsync(this System.Action action, CancellationToken cancellationToken = default)
    {
        return Task.Run(action, cancellationToken);
    }

    /// <summary>
    /// Creates a new Task, and then creates a new ValueTask from that
    /// </summary>
    public static ValueTask ToValueTask(this System.Action action)
    {
        var task = action.ToTask();
        return new ValueTask(task);
    }
}