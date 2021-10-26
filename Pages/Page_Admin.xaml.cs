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

namespace WPF_APP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_Admin.xaml
    /// </summary>
    public partial class Page_Admin : Page
    {
        public Page_Admin()
        {
            InitializeComponent();
        }

        public void ExitButton_Click(object sender, EventArgs args)
        {
            MainFrame.GetFrame().Navigate(new Page_Login());
        }
    }
}
