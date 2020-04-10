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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public ExpenseItHome()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report :";
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
            ExpenseDataSource = new List<Person>()
{
new Person()
{
Name="Mike",
Department ="Legal",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
}
},
new Person()
{
Name ="Nicole",
Department ="Marketing",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
}
},
new Person()
{
Name="James",
Department ="Engineering",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
new Expense() { ExpenseType="Software", ExpenseAmount=500 }
}
},
new Person()
{
Name="Tya",
Department ="Finance",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
}
},
new Person()
{
Name="David",
Department ="Marketing",
Expenses = new List<Expense>()
{
new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
}
}
};
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void PeopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }

        private void Button_Click_View_Expense_Report(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReportWindow = new ExpenseReport(this.peopleListBox.SelectedItem)
            {
                Height = this.Height,
                Width = this.Width
            };
            expenseReportWindow.ShowDialog();
        }
    }
}
