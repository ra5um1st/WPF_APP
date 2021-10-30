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
using WPF_APP.Model;

namespace WPF_APP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_Login.xaml
    /// </summary>
    public partial class Page_Login : Page
    {
        public Page_Login()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.GetFrame().Navigate(new Page_Registration());
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = pb_password.Password.GetHashCode().ToString();
                users user = BaseModel.GetContext().users.First(_user => _user.Login == tb_login.Text && _user.Password == password);
                switch (user.Role_id)
                {
                    case (int)Roles.ADMINISTRATOR:
                        MainFrame.GetFrame().Navigate(new Page_Admin());
                        break;
                    case (int)Roles.USER:
                        MainFrame.GetFrame().Navigate(new Page_User(user));
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Пользователь с указанным логином и/или паролем не найден или они не верны.");
            }
        }
    }
}
