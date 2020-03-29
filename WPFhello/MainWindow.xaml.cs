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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = createListBoxItemWithContent("James");
            ListBoxItem david = createListBoxItemWithContent("David");
            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            bool errorOccured = false;
            string text = "", messageBoxText;
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    if(((TextBox)item).Text.Length < 2)
                    {
                        errorOccured = true;
                        break;
                    }
                    text += ((TextBox)item).Text;
                    text += "\n";
                }
            }
            if(errorOccured) 
            {
                messageBoxText = "Error occured! Each text box has to be with 2 or more symbols.";
            }
            else 
            {
                messageBoxText = "Hello " + text + "!!!\nThis is your first program on Visual Studio 2019!";
            }
            MessageBox.Show(messageBoxText);
            clearFields();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to close the window?", "WPFhello", MessageBoxButton.YesNo);
            if(result.Equals(MessageBoxResult.No)) 
            {
                e.Cancel = true;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
            textBlock1.Text = DateTime.Now.ToString();
        }
        private void btnGreeting_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }

        private ListBoxItem createListBoxItemWithContent(String content)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = content;
            return item;
        }

        private void clearFields()
        {
            foreach(var item in MainGrid.Children) 
            {
                if(item is TextBox) 
                {
                    ((TextBox)item).Clear();
                }
            }
        }

    }
}
