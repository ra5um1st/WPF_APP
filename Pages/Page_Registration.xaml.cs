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
using WPF_APP;

namespace WPF_APP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_Registration.xaml
    /// </summary>
    public partial class Page_Registration : Page
    {
        public Page_Registration()
        {
            InitializeComponent();
            InitializeGenderComboBox();

            Remark.Text = "Поля со * ялвяются обязательными \nдля заполнения";
        }

        private void InitializeGenderComboBox()
        {
            cb_gender.ItemsSource = BaseModel.GetContext().genders.ToList();
            cb_gender.SelectedValuePath = "Id";
            cb_gender.DisplayMemberPath = "Value";
        }
            
        private void btnRegistate_Click(object sender, RoutedEventArgs e)
        {
            if (!StringExtension.IsDigitsOnly(tb_telephone.Text))
            {
                MessageBox.Show("Номер содержит некорректные символы. Убедитесь, что номер состоит только из цифр");
            }
            else if(pb_password.Password != pb_passwordVerification.Password)
            {
                MessageBox.Show("Введенные пароли не совпадают. Введите пароли еще раз.");
                pb_password.Password = "";
                pb_passwordVerification.Password = "";
            }
            else
            {
                users user = new users() { EMail = tb_email.Text, Login = tb_login.Text, Password = pb_password.Password, Role_id = (int)Roles.USER };
                BaseModel.GetContext().users.Add(user);

                try
                {
                    if (cb_gender.SelectedValue != null && StringExtension.IsDigitsOnly(tb_telephone.Text))
                    {
                        persons person = new persons() { Id = user.Id, FirstName = tb_firstname.Text, LastName = tb_lastname.Text, Gender_id = (int)cb_gender.SelectedValue, Telephone = Convert.ToInt32(tb_telephone.Text), DateOfBirth = dp_dateofbirth.SelectedDate };
                        BaseModel.GetContext().persons.Add(person);

                    }
                    else if (cb_gender.SelectedValue == null && !StringExtension.IsDigitsOnly(tb_telephone.Text))
                    {
                        persons person = new persons() { Id = user.Id, FirstName = tb_firstname.Text, LastName = tb_lastname.Text, Gender_id = null, Telephone = null, DateOfBirth = dp_dateofbirth.SelectedDate };
                        BaseModel.GetContext().persons.Add(person);
                    }
                    else if (cb_gender.SelectedValue == null)
                    {
                        persons person = new persons() { Id = user.Id, FirstName = tb_firstname.Text, LastName = tb_lastname.Text, Gender_id = null, Telephone = Convert.ToInt32(tb_telephone.Text), DateOfBirth = dp_dateofbirth.SelectedDate };
                        BaseModel.GetContext().persons.Add(person);
                    }
                    else
                    {
                        persons person = new persons() { Id = user.Id, FirstName = tb_firstname.Text, LastName = tb_lastname.Text, Gender_id = (int)cb_gender.SelectedValue, Telephone = null, DateOfBirth = dp_dateofbirth.SelectedDate };
                        BaseModel.GetContext().persons.Add(person);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при обновлении данных");
                }

                finally
                {
                    BaseModel.GetContext().SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались");
                    MainFrame.GetFrame().Navigate(new Page_User(user));
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GetFrame().Navigate(new Page_Login());
        }
    }
}
