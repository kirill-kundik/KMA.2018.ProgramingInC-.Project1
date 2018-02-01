using System.Windows;

namespace KMA.Group2.Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SignInWindow w = new SignInWindow();
            w.ShowDialog();
        }
    }
}
