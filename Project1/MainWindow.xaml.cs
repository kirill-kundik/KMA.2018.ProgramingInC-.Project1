using System.ComponentModel;
using System.Windows;
using FontAwesome.WPF;

namespace KMA.Group2.Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SignInWindow _signInView;
        private SignUpView _signUpView;
        private ImageAwesome _loader;
        public MainWindow()
        {
            InitializeComponent();
            ShowSignInView();
        }

        private void ShowSignInView()
        {
            Grid.Children.Clear();
            if (_signInView == null)
            {
                _signInView = new SignInWindow(ShowMainView,ShowSignUpView, Close, ShowLoader);
            }
            Grid.Children.Add(_signInView);
        }

        private void ShowSignUpView()
        {
            Grid.Children.Clear();
            if (_signUpView == null)
            {
                _signUpView = new SignUpView(ShowMainView, ShowSignInView, ShowLoader);
            }
            Grid.Children.Add(_signUpView);
        }

        private void ShowMainView()
        {
            Grid.Children.Clear();
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(Grid, ref _loader, isShow);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DBAdapter.SaveData();
            base.OnClosing(e);
        }
    }
}
