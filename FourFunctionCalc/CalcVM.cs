using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FourFunctionCalc
{
    public class CalcVM : INotifyPropertyChanged
    {
        private readonly CalcLogic _logic; 
        private string _display;
        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand AddToDisplay { get; }

        public CalcVM()
        {
            Display = "0";
            _logic = new CalcLogic();
            AddToDisplay = new DelegateCommand(AddToDisplayInternal);
        }



        
        private void AddToDisplayInternal(object num)
        {
            if (Display.Equals("0")) // Replaces the 0 in a blank calculator
                Display = (string)num;
            else if (Display.Length < 10) // Caps Display to a length of 10
                Display += num;
        }

        public void ClearDisplay()
        {
            Display = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
