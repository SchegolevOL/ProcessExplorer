namespace ProcessExplorer.WindowModels;

public class ModulesWindowModel : BaseWindowModel
{
    private string _message;
    public string Message
    {
        get => _message; 
        set => SetField(ref _message, value);
    }
}