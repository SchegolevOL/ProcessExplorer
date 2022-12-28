using System.Windows;
using ProcessExplorer.WindowModels;

namespace ProcessExplorer.Windows.ModulesWindow;

public partial class ModulesWindow : Window
{
    public ModulesWindow(BaseWindowModel windowModel)
    {
        InitializeComponent();
        DataContext = windowModel;
    }
}