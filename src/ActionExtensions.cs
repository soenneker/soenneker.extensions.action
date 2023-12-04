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
    /// Equivalent to <code>Task.Run(action).ConfigureAwait(false)</code>
    /// </summary>
    public static async ValueTask RunAsync(this System.Action action)
    {
        await Task.Run(action);
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