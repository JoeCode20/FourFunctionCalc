using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourFunctionCalc
{
    public class CalcLogic
    {
        #region Fields
        private string _firstNum;
        private string _secondNum;
        private string _operation;
        #endregion

        #region Properties
        public string FirstNum
        {
            get => _firstNum;
            set
            {
                _firstNum = value;
            }
        }

        public string SecondNum
        {
            get => _secondNum;
            set
            {
                _secondNum = value;
            }
        }

        public string Operation
        {
            get => _operation;
            set
            {
                _operation = value;
            }
        }
        #endregion

        public CalcLogic()
        {
            FirstNum = "0";
            SecondNum = "0";
            Operation = "0";
        }
        public string Calculate(string firstNum, string secondNum, string operation)
        {
            string result = "0";
            double num1 = Double.Parse(firstNum);
            double num2 = Double.Parse(secondNum);

            switch (operation)
            {
                case "+":
                    result = (num1 + num2).ToString();
                    break;
                case "-":
                    result = (num1 - num2).ToString();
                    break;
                case "*":
                    result = (num1 * num2).ToString();
                    break;
                case "/":
                    result = (num1 / num2).ToString();
                    break;
                default:
                    break;
            }
            if (result.Length > 10)
                result.Remove(11, result.Length);

            return result;
        }
    }
}
