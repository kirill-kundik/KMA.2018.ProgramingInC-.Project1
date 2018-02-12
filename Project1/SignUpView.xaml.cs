using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome.WPF;

namespace KMA.Group2.Project1
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView(Action signUpSuccessAction,
            Action cancelAction,
            Action<bool> showLoaderAction)
        {
            InitializeComponent();
            DataContext = new SignUpViewModel(signUpSuccessAction, cancelAction, showLoaderAction);
        }
    }
}
