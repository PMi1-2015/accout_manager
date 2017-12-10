using AccountSystem.Data.models;
using AccountSystem.Services;
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

namespace AccountSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAppUserService _userService;

        public MainWindow(IAppUserService userService)
        {
            InitializeComponent();

            _userService = userService;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            String username = UsernameField.Text;
            String password = PasswordField.Password;

            if (_userService.AuthenticateUser(username, password))
            {
                var managementWindow = new ManagementWindow();
                Application.Current.MainWindow = managementWindow;
                this.Close();
                managementWindow.Show();
            }
            else
            {
                button.IsEnabled = true;
                ErrorLabel.Content = "Invalid credentials";
            }
        }
    }
}
