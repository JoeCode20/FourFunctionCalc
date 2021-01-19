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
        #region Fields
        private readonly CalcLogic _logic; 
        private string _display;
        #endregion

        #region Properties
        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Constructors
        public CalcVM()
        {
            _logic = new CalcLogic();
            Display = "0";
            AddToDisplay = new DelegateCommand(AddToDisplayInternal);
            Calculation = new DelegateCommand(CalculationInternal);
            SetOperation = new DelegateCommand(SetOperationInternal);
        }
        #endregion

        #region Commands
        public ICommand AddToDisplay { get; }
        public ICommand SetOperation { get; }
        public ICommand Calculation { get; }
        
        #endregion

        private void AddToDisplayInternal(object param)
        {
            switch (param)
            {
                case "Clear":
                    Display = "0";
                    _logic.FirstNum = "0";
                    _logic.SecondNum = "0";
                    _logic.Operation = string.Empty; 
                    break;

                case "-":
                    if (Display.Contains("-"))
                        Display = Display.Remove(Display.IndexOf("-"), 1);
                    else
                        Display = "-" + Display;
                    break;

                default:
                    if (Display.Equals("0"))
                        Display = (string)param;
                    else if (Display.Length < 10)
                        Display += param;
                    break;

            }
        }

        private void SetOperationInternal(object param)
        {
            _logic.FirstNum = Display;
            _logic.Operation = param.ToString();
            Display = "0";
        }

        private void CalculationInternal(object param)
        {
            _logic.SecondNum = Display;
            Display = _logic.Calculate(_logic.FirstNum, _logic.SecondNum, _logic.Operation);
        }




        #region Event Stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
    }
}
