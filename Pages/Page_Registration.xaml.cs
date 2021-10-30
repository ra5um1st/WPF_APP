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
using WPF_APP.Model;

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
            
        public void btnRegistate_Click(object sender, RoutedEventArgs e)
        {
            users user = RegistrateUser();
            if (user != null)
            {
                MainFrame.GetFrame().Navigate(new Page_User(user));
            }
        }

        public void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GetFrame().Navigate(new Page_Login());
        }
        public users RegistrateUser()
        {
            if(tb_email.Text == string.Empty || tb_login.Text == string.Empty  || pb_password.Password == string.Empty)
            {
                MessageBox.Show("Заполните обязательные поля!");
                return null;
            }
            else if (!StringExtension.IsDigitsOnly(tb_telephone.Text))
            {
                MessageBox.Show("Номер содержит некорректные символы. Убедитесь, что номер состоит только из цифр");
                return null;
            }
            else if (pb_password.Password.GetHashCode() != pb_passwordVerification.Password.GetHashCode())
            {
                MessageBox.Show("Введенные пароли не совпадают. Введите пароли еще раз.");
                pb_password.Password = "";
                pb_passwordVerification.Password = "";
                return null;
            }
            else
            {
                try
                {
                    users user = new users() { EMail = tb_email.Text, Login = tb_login.Text, Password = pb_password.Password.GetHashCode().ToString(), Role_id = (int)Roles.USER };
                    persons person = new persons();

                    if (cb_gender.SelectedValue != null)
                    {
                        person.Gender_id = (int)cb_gender.SelectedValue;
                    }
                    if (StringExtension.IsDigitsOnly(tb_telephone.Text))
                    {
                        if(tb_telephone.Text != string.Empty)
                        {
                            person.Telephone = Convert.ToInt32(tb_telephone.Text);
                        }
                        else
                        {
                            person.Telephone = null;
                        }
                    }

                    person.FirstName = tb_firstname.Text;
                    person.LastName = tb_lastname.Text;
                    person.DateOfBirth = dp_dateofbirth.SelectedDate;
                    BaseModel.GetContext().users.Add(user);
                    BaseModel.GetContext().persons.Add(person);
                    BaseModel.GetContext().SaveChanges();
                    MessageBox.Show("Регистрация пользователя завершена успешно!");
                    return user;
                }
                catch(Exception e)
                {
                    MessageBox.Show("Ошибка при добавлнении данных!\n"+ e.Message);
                    return null;
                }
            }
        }
    }
}