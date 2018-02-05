using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMA.Group2.Project1.Annotations;

namespace KMA.Group2.Project1
{
    class SignUpViewModel: INotifyPropertyChanged
    {
        private string _password;
        private string _login;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;
        private RelayCommand _signUpCommand;
        private Action<bool> _showLoaderAction;
        private readonly Action _closeAction;

        public SignUpViewModel(Action close, Action<bool> showLoader)
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

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand(SignUpImpl,
                           o => !String.IsNullOrWhiteSpace(_login) &&
                                !String.IsNullOrWhiteSpace(_password) &&
                                !String.IsNullOrWhiteSpace(_firstName) &&
                                !String.IsNullOrWhiteSpace(_lastName) &&
                                !String.IsNullOrWhiteSpace(_email) &&
                                _dateOfBirth != DateTime.MinValue));

            }
        }

        private async void SignUpImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            await Task.Run((() =>
            {
                StationManager.CurrentUser = DBAdapter.SignUp(_login, _password, _firstName, _lastName, _email, _dateOfBirth);
                Thread.Sleep(2000);
            }));
            
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
