using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Task2.ViewModels;

namespace Task2.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}