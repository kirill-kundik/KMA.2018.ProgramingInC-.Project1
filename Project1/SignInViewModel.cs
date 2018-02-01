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
        private Action<bool> _showLoaderAction;
        private readonly Action _closeAction;

        public SignInViewModel(Action close, Action<bool> showLoader)
        {
            _closeAction = close;
            _showLoaderAction = showLoader;
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

        private async void SignInImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            await Task.Run((() =>
            {
                StationManager.CurrentUser = DBAdapter.SignIn(_login, _password);
                Thread.Sleep(2000);
            }));
            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Login {_login} or password are invalid.");
            else
            {
                MessageBox.Show("Successfully log in");
                _closeAction.Invoke();
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
