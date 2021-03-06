﻿using System;
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
using System.Data;
using System.Data.SqlClient;
using UserLogin;
using MySql.Data.MySqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            /*FillStudStatusChoices();
            this.DataContext = this;
            _studentInfoContext = new StudentInfoContext();*/
        }

        public MainWindow(object data) : this()
        {
            MainFormVM mainFormVM = new MainFormVM
            {
                CurrentStudent = (Student)data
            };
            Title = mainFormVM.Title;
            this.DataContext = mainFormVM;
        }

        public List<string> StudStatusChoices { get; set; }

        /*private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }*/

        /*public bool TestStudentsIfEmpty()
        {
            IEnumerable<Student> queryStudents = _studentInfoContext.Students;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }

        public void CopyTestStudents()
        {
            foreach (Student student in StudentData.TestStudents)
            {
                _studentInfoContext.Students.Add(student);
            }
            _studentInfoContext.SaveChanges();
        }*/

        private void ResetFields(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void DisableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox textBox)
                {
                    textBox.IsEnabled = false;
                }
            }
        }

        private void EnableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox textBox)
                {
                    textBox.IsEnabled = true;
                }
            }
        }
    }
}
