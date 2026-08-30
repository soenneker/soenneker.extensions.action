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
    /// <returns>A task equivalent to <code>new Task(action)</code>.</returns>
    public static Task ToTask(this System.Action action)
    {
        return new Task(action);
    }

    /// <summary>
    /// Equivalent to <code>Task.Run(action)</code>
    /// </summary>
    /// <returns>A task equivalent to <code>Task.Run(action)</code>.</returns>
    public static Task RunAsync(this System.Action action, CancellationToken cancellationToken = default)
    {
        return Task.Run(action, cancellationToken);
    }

    /// <summary>
    /// Invokes the action synchronously and returns a completed value task, or a faulted value task when the action throws.
    /// </summary>
    /// <returns>A completed or faulted value task representing the invocation.</returns>
    public static ValueTask ToValueTask(this System.Action action)
    {
        try
        {
            action();
            return ValueTask.CompletedTask;
        }
        catch (System.Exception exception)
        {
            return ValueTask.FromException(exception);
        }
    }
}
