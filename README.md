[![](https://img.shields.io/nuget/v/soenneker.extensions.action.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.action/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.action/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.action/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.action.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.action/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.action/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.action/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Action

Small, focused extension methods for turning an `Action` into a `Task` or `ValueTask`, or running it asynchronously.

## Installation

```bash
dotnet add package Soenneker.Extensions.Action
```

## Quick start

```csharp
using Soenneker.Extensions.Action;

Action writeHello = () => Console.WriteLine("Hello");

Task unstartedTask = writeHello.ToTask();
Task runningTask = writeHello.RunAsync();
ValueTask valueTask = writeHello.ToValueTask();
```

`ToTask()` creates an unstarted task. Use `RunAsync()` when the action should begin running immediately.

## Available methods

- `ToTask()` - Equivalent to `new Task(action)`
- `RunAsync()` - Equivalent to `Task.Run(action)`
- `ToValueTask()` - Creates a new Task, and then creates a new ValueTask from that.
