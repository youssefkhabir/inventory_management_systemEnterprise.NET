using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ABBk_ARP.Model;
using ABBk_ARP.Repository;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ABBk_ARP.ViewModel
{
    public class UsersViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password; //for better security
                                        //rivate string _username;
        private string _name;
        private string _lastname;
        private string _email;
        private string _errorMessage;
        //Properties
        private IUserRepository userRepository;


        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }

        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

    }
   
}
