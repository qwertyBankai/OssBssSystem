using OssBssSystem.DataLayer;
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

namespace OssBssSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        DataManager context = new DataManager();
        string randomString;
        public Authorization()
        {
            InitializeComponent();
        }

        int loginUser = 0;
        string passwordUser = "0";

        public void Validation(object sender, KeyEventArgs e)
        {
            if ( loginUser.ToString() != login.Text && passwordUser.ToString() != password.Text)
            {
                if (e.Key == Key.Enter)
                {
                    if (!(String.IsNullOrEmpty(login.Text)) && !(String.IsNullOrEmpty(password.Text)))
                    {
                        loginUser = Convert.ToInt32(login.Text);
                        passwordUser = password.Text;
                        if (context.Staffs.Any(x => x.Number == loginUser && x.Password == passwordUser))
                        {
                            var rand = new Random();
                            var s = new StringBuilder();
                            for (int i = 1; i < 8; i++)
                            {
                                s.Append((char)rand.Next('1', 'z'));
                            }
                            randomString = s.ToString();
                            textGeneration.IsEnabled = true;
                            AutorizationBtn.IsEnabled = true;
                            RefreshBtn.IsEnabled = true;
                            MessageBox.Show(randomString);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните поля!");
                    }
                }
            }
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if( !(String.IsNullOrEmpty(textGeneration.Text)) && textGeneration.Text.Equals(randomString))
            {
                NavigationService.Navigate(new AccountPage());
            }
            else
            {
                MessageBox.Show("Введены неверные данные!");
            }
        }

        private void RefreshGenerationCode(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            var s = new StringBuilder();
            for (int i =1; i < 8; i++)
            {
                s.Append((char)rand.Next('1', 'z'));
            }

            randomString = s.ToString();
            MessageBox.Show(randomString);
        }

        private void LoginInput(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var loginText = Convert.ToInt32(login.Text);
                if (context.Staffs.Any(x => x.Number == loginText))
                {
                    password.IsEnabled = true;
                }
            }
        }
    }
}
