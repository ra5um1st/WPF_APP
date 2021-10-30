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
using System.Windows.Shapes;
using WPF_APP.Model;
using WPF_APP.Pages;

namespace WPF_APP.Windows
{
    /// <summary>
    /// Логика взаимодействия для InsertUserWindow.xaml
    /// </summary>
    public partial class InsertUserWindow : Window
    {
        Page_Registration page;
        public InsertUserWindow()
        {
            InitializeComponent();
            page = new Page_Registration();
            page.btnRegistate.Content = "Добавить";
            page.btnBack.Content = "Отмена";
            page.btnBack.Click -= page.btnBack_Click;
            page.btnRegistate.Click -= page.btnRegistate_Click;
            page.btnBack.Click += (object sender, RoutedEventArgs e) => this.Close();
            page.btnRegistate.Click += (object sender, RoutedEventArgs e) =>
            {
                users user = page.RegistrateUser();
                if(user != null)
                {
                    this.Close();
                }
            };
            frame.Navigate(page);
        }
    }
}
