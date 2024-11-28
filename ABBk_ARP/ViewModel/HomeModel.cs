using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ABBk_ARP.Model;
using ABBk_ARP.Repository;
using System.ComponentModel;
using ABBk_ARP.Model;
using FontAwesome.Sharp;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace ABBk_ARP.ViewModel
{
    public class HomeModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        private ViewModelBase _currentChildeView;
        private string _caption;
        private IconChar _icon;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildeView {
            get { 
                
                return
                _currentChildeView; 
            }



            set {
                _currentChildeView = value;
                OnPropertyChanged(nameof(CurrentChildeView));
            }
    }









        public string Caption {
            get
            {

                return
                _caption ;
            }



            set
            {
                _caption= value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon {
            get
            {

                return
                _icon;
            }



            set
            {
                _icon= value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        //-- user interaction commands 


        public ICommand ShowHomeViewCommand { get; }// dashboard
        public ICommand ShowCustomersViewCommand { get; }
        public ICommand ShowProductViewCommand { get; }



        public ICommand ShowCategoryViewCommand { get; }
        public ICommand ShowSupplierViewCommand { get; }
        public ICommand ShowPurchasesViewCommand { get; }

        public ICommand ShowUsersViewCommand { get; }

        public ICommand ShowReportsViewCommand { get;  }
        /// <summary>
        ///  public ICommand ShowProductViewCommand { get; }// dashboard
        /// public ICommand ShowCategoryViewCommand { get; }
        /// .
        /// .....
        /// </summary>

        public HomeModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();


            // initilaize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomersViewCommand = new ViewModelCommand(ExecuteCustomersViewCommand);
//kmel b9i
            ShowProductViewCommand = new ViewModelCommand(ExecuteProductViewCommand);

            ShowCategoryViewCommand = new ViewModelCommand(ExecuteCategoryViewCommand);
            ShowSupplierViewCommand = new ViewModelCommand(ExecuteSupplierViewCommand);
            ShowPurchasesViewCommand = new ViewModelCommand(ExecutePurchasesViewCommand);
            ShowUsersViewCommand = new ViewModelCommand(ExecuteUsersViewCommand);


            ShowReportsViewCommand = new ViewModelCommand(ExecuteReportsViewCommand);
            //default View 
            ExecuteShowHomeViewCommand(null);


            LoadCurrentUserData();
        }

        private void ExecuteCustomersViewCommand(object obj)
        {
            CurrentChildeView = new CustomerViewModel();
            Caption = "customer";
            Icon = IconChar.UserGroup; 
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildeView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteProductViewCommand(object obj)
        {
            CurrentChildeView = new ProductViewModel();
            Caption = "Product";
            Icon = IconChar.Box;
        }


        private void ExecuteCategoryViewCommand(object obj)
        {
            CurrentChildeView = new CategoryViewModel();
            Caption = "Category";
            Icon = IconChar.LayerGroup;
        }

        private void ExecuteSupplierViewCommand(object obj)
        {
            CurrentChildeView = new SupplierVieModel();
            Caption = "Supplier";
            Icon = IconChar.Truck;
        }
        private void ExecutePurchasesViewCommand(object obj)
        {
            CurrentChildeView = new PurchasesViewModel();
            Caption = "Purchases";
            Icon = IconChar.MoneyCheckDollar;
        }
        private void ExecuteUsersViewCommand(object ob) {
            CurrentChildeView = new UsersViewModel();
            Caption = "Users";
            Icon = IconChar.Users;
        }
        private void ExecuteReportsViewCommand(object obj)
        {
            CurrentChildeView = new ReportsViewModel();
            Caption = "Report";
            Icon = IconChar.PieChart;
        }
        // rak tansa l5rin 

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"greetings {user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }
    }
}