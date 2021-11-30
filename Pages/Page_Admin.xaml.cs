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
using WPF_APP.Windows;

namespace WPF_APP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_Admin.xaml
    /// </summary>
    public partial class Page_Admin : Page
    {
        List<persons> persons;
        public Page_Admin()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs args)
        {
            MainFrame.GetFrame().Navigate(new Page_Login());
        }

        private void cb_gender_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox gender = (ComboBox)sender;
            gender.ItemsSource = BaseModel.GetContext().genders.ToList();
            gender.SelectedValuePath = "Id";
            gender.DisplayMemberPath = "Value";
            if(persons.First(person => person.Id == Convert.ToInt32(gender.Uid)).Gender_id != null)
            {
                gender.SelectedValue = persons.First(person => person.Id == Convert.ToInt32(gender.Uid)).genders.Id;
            }
        }

        private void UserList_Loaded(object sender, RoutedEventArgs e)
        {
            SetListBoxData();
        }
        
        private void SetListBoxData()
        {
            persons = BaseModel.GetContext().persons.ToList();
            UserList.ItemsSource = persons;
        }

        private void InsertButton_Click(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            InsertUserWindow window = new InsertUserWindow();
            window.Topmost = true;
            window.ShowDialog();
            SetListBoxData();
        }
        private void DeleteButton_Click(object sender, EventArgs args)
        {
            if (UserList.SelectedItem != null)
            {
                switch (MessageBox.Show("Вы точно хотите удалить выбранного пользователя?", "Удаление", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        try
                        {

                            persons person = persons[UserList.SelectedIndex];
                            MessageBox.Show("Пользователь с логином " + person.users.Login + " был удален!");
                            BaseModel.GetContext().persons.Remove(person);
                            BaseModel.GetContext().SaveChanges();
                            SetListBoxData();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Не удалось удалить пользователя.\n" + e.Message, "Ошибка");
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали пользователя для удаления.");
            }
        }

        private void DeleteButton_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
