using System;
using System.Windows.Input;

namespace ProcessExplorer.WindowModels;

public class LambdaCommand : ICommand
{
    public Func<bool>? CanExecuteDelegate { get; init; }
    public Action? ExecuteDelegate { get; init; }

    public bool CanExecute(object? parameter)
    {
        return CanExecuteDelegate?.Invoke() ?? true ;
    }

    public void Execute(object? parameter)
    {
        ExecuteDelegate?.Invoke();
    }

    public event EventHandler? CanExecuteChanged;

    public void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}