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
    /// Логика взаимодействия для Page_User.xaml
    /// </summary>
    public partial class Page_User : Page
    {
        users user;
        bool isEditable = false;

        public Page_User(users user)
        {
            InitializeComponent();

            this.user = user;
            InitializeData();
        }

        private void InitializeData()
        {
            try
            {
                tb_firstname.Text = user.persons.FirstName;
                tb_lastname.Text = user.persons.LastName;
                cb_gender.ItemsSource = BaseModel.GetContext().genders.ToList();
                cb_gender.SelectedValuePath = "Id";
                cb_gender.DisplayMemberPath = "Value";

                if (user.persons.genders != null)
                {
                    cb_gender.SelectedValue = user.persons.genders.Id;
                }

                dp_dateofbirth.SelectedDate = user.persons.DateOfBirth;
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке страницы");
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if(isEditable == false)
            {
                isEditable = true;
                btnChange.Content = "Сохранить";
                tb_firstname.IsEnabled = true;
                tb_lastname.IsEnabled = true;
                cb_gender.IsEnabled = true;
                tb_telephone.IsEnabled = true;
                dp_dateofbirth.IsEnabled = true;
            }
            else
            {
                isEditable = false;
                btnChange.Content = "Изменить";
                tb_firstname.IsEnabled = false;
                tb_lastname.IsEnabled = false;
                cb_gender.IsEnabled = false;
                cb_gender.IsEnabled = false;
                dp_dateofbirth.IsEnabled = false;

                try
                {
                    if (cb_gender.SelectedValue != null && StringExtension.IsDigitsOnly(tb_telephone.Text))
                    {
                        persons person = BaseModel.GetContext().persons.Find(user.Id);
                        person.FirstName = tb_firstname.Text;
                        person.LastName = tb_lastname.Text;
                        person.Gender_id = (int)cb_gender.SelectedValue;
                        person.Telephone = Convert.ToInt32(tb_telephone.Text);
                        person.DateOfBirth = dp_dateofbirth.SelectedDate;
                        BaseModel.GetContext().SaveChanges();
                        MessageBox.Show("Изменения успешно сохранены");

                    }
                    else if(cb_gender.SelectedValue == null && !StringExtension.IsDigitsOnly(tb_telephone.Text))
                    {           
                        persons person = BaseModel.GetContext().persons.Find(user.Id);
                        person.FirstName = tb_firstname.Text;
                        person.LastName = tb_lastname.Text;
                        person.Gender_id = null;
                        person.Telephone = null;
                        person.DateOfBirth = dp_dateofbirth.SelectedDate;

                        BaseModel.GetContext().SaveChanges();
                        MessageBox.Show("Изменения успешно сохранены");
                    }
                    else if(cb_gender.SelectedValue == null)
                    {
                        persons person = BaseModel.GetContext().persons.Find(user.Id);
                        person.FirstName = tb_firstname.Text;
                        person.LastName = tb_lastname.Text;
                        person.Gender_id = null;
                        person.Telephone = Convert.ToInt32(tb_telephone.Text);
                        person.DateOfBirth = dp_dateofbirth.SelectedDate;
                        BaseModel.GetContext().SaveChanges();
                        MessageBox.Show("Изменения успешно сохранены");
                    }
                    else
                    {
                        persons person = BaseModel.GetContext().persons.Find(user.Id);
                        person.FirstName = tb_firstname.Text;
                        person.LastName = tb_lastname.Text;
                        person.Gender_id = (int)cb_gender.SelectedValue;
                        person.Telephone = null;
                        person.DateOfBirth = dp_dateofbirth.SelectedDate;
                        BaseModel.GetContext().SaveChanges();
                        MessageBox.Show("Изменения успешно сохранены");
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при обновлении данных");
                }
                finally
                {
                    InitializeData();
                }
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GetFrame().RemoveBackEntry();
            MainFrame.GetFrame().Navigate(new Page_Login());
        }
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
