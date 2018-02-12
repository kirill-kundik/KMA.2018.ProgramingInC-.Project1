using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMA.Group2.Project1.Annotations;

namespace KMA.Group2.Project1
{
    class SignInViewModel: INotifyPropertyChanged
    {
        private string _password;
        private string _login;
        private RelayCommand _signInCommand;
        private RelayCommand _signUpCommand;
        private RelayCommand _closeCommand;
        private Action<bool> _showLoaderAction;
        private readonly Action _signInSuccessAction;
        private readonly Action _showSignUpAction;
        private readonly Action _closeAction;

        public SignInViewModel(Action signInSuccessAction,
            Action showSignUpAction,
            Action closeAction,
            Action<bool> showLoaderAction)
        {
            _closeAction = closeAction;
            _showLoaderAction = showLoaderAction;
            _signInSuccessAction = signInSuccessAction;
            _showSignUpAction = showSignUpAction;
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value; 
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand(SignInImpl,
                           o => !String.IsNullOrWhiteSpace(_login) &&
                                !String.IsNullOrWhiteSpace(_password)));
            }
        }

        public RelayCommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new RelayCommand(o => _showSignUpAction.Invoke())); }
        }

        public RelayCommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand(o => _closeAction.Invoke())); }
        }

        private async void SignInImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            await Task.Run((() =>
            {
                StationManager.CurrentUser = DBAdapter.SignIn(_login, _password);
                Thread.Sleep(5000);
            }));
            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Login {_login} or password are invalid.");
            else
            {
                MessageBox.Show("Successfully log in");
                _signInSuccessAction.Invoke();
            }
            _showLoaderAction.Invoke(false);
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
