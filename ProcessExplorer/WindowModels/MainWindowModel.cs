using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using ProcessExplorer.Windows.FindWindow;
using ProcessExplorer.Windows.ModulesWindow;

namespace ProcessExplorer.WindowModels;

public class MainWindowModel : BaseWindowModel
{
    public ObservableCollection<Process> Processes { get; set; }

    private Process _process;
    public Process SelectedProcess
    {
        get => _process; 
        set => SetField(ref _process, value);
    }

    public LambdaCommand CommandAbout { get; init; }
    public LambdaCommand CommandFind { get; init; }

    public MainWindowModel()
    {
        Processes = new ObservableCollection<Process>(Process.GetProcesses());

        CommandAbout = new LambdaCommand
        {
            CanExecuteDelegate = null,
            ExecuteDelegate = () =>
            {
                var str = new StringBuilder();
                var modules = Process.GetProcessById(SelectedProcess.Id).Modules;
                foreach (ProcessModule module in modules)
                {
                    str.Append($"{module.ModuleName}\n");
                }

                var modulesWindow = new ModulesWindow(new ModulesWindowModel
                {
                    Message = str.ToString()
                });
                modulesWindow.Show();
            }
        };

        CommandFind = new LambdaCommand
        {
            CanExecuteDelegate = null,
            ExecuteDelegate = () =>
            {
                new FindWindow().Show();
                
                var id = Application.Current.Resources["Id"];
                MessageBox.Show($"ID - {id}");
            }
        };
    }
}