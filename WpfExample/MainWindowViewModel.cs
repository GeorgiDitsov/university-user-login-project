using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand
        { get; set; }
        private bool canExecute = true;
        private string lblHi = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string HiLabelContent 
        {
            get { return lblHi; }
            set 
            {
                if (lblHi != value) 
                {
                    this.lblHi = value;
                    PropChanged("lblHi");
                }
            }
        }
        public string HiButtonContent
        {
            get { return "click to hi"; }
        }
        public string CurrentDateTime
        {
            get { return DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(); }
        }
        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                { return; }
                this.canExecute = value;
            }
        }
        public ICommand ToggleExecuteCommand
        {
            get
            { return toggleExecuteCommand; }
            set
            { toggleExecuteCommand = value; }
        }
        public ICommand HiButtonCommand
        {
            get
            { return hiButtonCommand; }
            set
            { hiButtonCommand = value; }
        }
        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public void ShowMessage(object obj)
        {
            HiLabelContent = obj.ToString();
        }
        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
    }
}