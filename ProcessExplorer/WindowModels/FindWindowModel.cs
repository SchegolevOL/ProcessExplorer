using System.Windows;

namespace ProcessExplorer.WindowModels;

public class FindWindowModel : BaseWindowModel
{
    private int _id;
    public int Id
    {
        get => _id;
        set => SetField(ref _id, value);
    }

    public LambdaCommand CommandFind { get; init; }

    public FindWindowModel()
    {
        CommandFind = new LambdaCommand
        {
            CanExecuteDelegate = null,
            ExecuteDelegate = () =>
            {
                Application.Current.Resources["Id"] = Id;
            }
        };
    }
}