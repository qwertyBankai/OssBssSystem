﻿using OssBssSystem.DataLayer;
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
        public Authorization()
        {
            InitializeComponent();
        }
        
        public void Validation(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if( !(String.IsNullOrEmpty(login.Text)) && !(String.IsNullOrEmpty(password.Text)) )
                {
                    string loginUser = login.Text;
                    string passwordUser = login.Text;
                    if(context.Staffs.Any(x=> x.Number == Convert.ToInt32(loginUser) && x.Password == passwordUser))
                    {
                        MessageBox.Show("!!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля!");
                }
            }
        }
    }
}