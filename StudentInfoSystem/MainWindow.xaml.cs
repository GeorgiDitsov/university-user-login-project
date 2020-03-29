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
            Title = "Студентска информационна система";
        }

        public void FillStudentDataIntoFields(Student student)
        {
            txtName.Text = student.FirstName;
            txtSurname.Text = student.Surname;
            txtLastName.Text = student.LastName;
            txtFaculty.Text = student.Faculty;
            txtProgramme.Text = student.Programme;
            txtOKS.Text = student.Qualification.ToString();
            txtStatus.Text = student.Status.ToString();
            txtCourse.Text = student.Course;
            txtStream.Text = student.Stream;
            txtGroup.Text = student.Group;
            txtFacultyNumber.Text = student.FacultyNumber;
        }

        private void ResetFields(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Clear();
                }
            }
        }

        private void DisableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = false;
                }
            }
        }

        private void EnableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = true;
                }
            }
        }
    }
}
