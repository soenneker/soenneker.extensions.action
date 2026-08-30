[![](https://img.shields.io/nuget/v/soenneker.extensions.action.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.action/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.action/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.action/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.action.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.action/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.action/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.action/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Action

Adapters for representing or running a synchronous `Action` as a `Task` or `ValueTask`.

## Installation

```bash
dotnet add package Soenneker.Extensions.Action
```

## Quick start

```csharp
using Soenneker.Extensions.Action;

Action writeHello = () => Console.WriteLine("Hello");

Task unstarted = writeHello.ToTask();
unstarted.Start();
await unstarted;

await writeHello.RunAsync();

await writeHello.ToValueTask();
```

## Behavior

| Method | Invocation behavior | Exception behavior |
| --- | --- | --- |
| `ToTask()` | Returns a task in `Created` state; the action has not run | Captured by the task after it is started |
| `RunAsync(token)` | Queues the action to the thread pool immediately | Captured by the returned task |
| `ToValueTask()` | Runs the action synchronously during the call | Returned as a faulted `ValueTask` |

Do not await the result of `ToTask()` until it has been started. A task can be started only once; call `Start()` or `RunSynchronously()` with the scheduler behavior your application requires. Use `RunAsync()` when thread-pool scheduling is actually appropriate.

`RunAsync()` does not make blocking or CPU-heavy code scalable, and it should not replace a naturally asynchronous I/O API. Its cancellation token can prevent the action from being scheduled when cancellation wins first, but the `Action` itself receives no token and cannot be cooperatively stopped once running.

`ToValueTask()` does not move work to another thread. It is useful when a synchronous callback must satisfy a value-task-shaped contract without allocating a `Task`; callers must still await the returned value to observe any exception.
