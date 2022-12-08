using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _21stMortgageInterviewApplication
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region <Properties>

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _inputValues;
        private int _outputValue;
        private bool _isOutputOdd;
        private bool _isOutputPositive;


        public string InputValues
		{
			get { return _inputValues; }
			set 
            {
                _inputValues = value;
                NotifyPropertyChanged();
            }
		}


        public int OutputValue
        {
            get { return _outputValue; }
            set
            {
                _outputValue = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsOutputOdd
        {
            get { return _isOutputOdd; }
            set 
            { 
                _isOutputOdd = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsOutputPositive
        {
            get { return _isOutputPositive; }
            set
            {
                _isOutputPositive = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        public ICommand FindLargestValueCommand
        {
            get
            {
                return new RelayCommand(FindLargestValue);
            }
        }

        public ICommand FindSumOfOddCommand
        {
            get
            {
                return new RelayCommand(FindSumOfOddNumbers);
            }
        }

        public ICommand FindSumOfEvenCommand
        {
            get
            {
                return new RelayCommand(FindSumOfEvenNumbers);
            }
        }

        public MainWindowViewModel()
        {
            _inputValues = "";
            _outputValue = 0;
            _isOutputOdd = false;
            _isOutputPositive = true;
        }

        private bool IsValueOdd(int value)
        {
            if (value % 2 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsValuePositive(int value)
        {
            if (value >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int[] GetNumbersFromInput()
        {
            string[] tmpValues = _inputValues.Split(',');
            int[] intValues = new int[tmpValues.Length];

            for (int i = 0; i < tmpValues.Length; i++)
            {
                int.TryParse(tmpValues[i], out intValues[i]);
            }

            return intValues;
        }

        public void FindLargestValue(object parameter)
        {
            int largestValue = FindSmallestValue();
            int[] intValues = GetNumbersFromInput();

            for (int i = 0; i < intValues.Length; i++)
            {
                if (intValues[i] > largestValue)
                {
                    largestValue = intValues[i];
                }
            }

            OutputValue = largestValue;
            IsOutputOdd = IsValueOdd(largestValue);
            IsOutputPositive = IsValuePositive(largestValue);
        }

        public void FindSumOfOddNumbers(object parameter)
        {
            int totalValue = 0;
            int[] intValues = GetNumbersFromInput();

            for (int i = 0; i < intValues.Length; i++)
            {
                if (IsValueOdd(intValues[i]))
                {
                    totalValue += intValues[i];
                }
            }

            OutputValue = totalValue;
            IsOutputOdd = IsValueOdd(totalValue);
            IsOutputPositive = IsValuePositive(totalValue);
        }

        // do this incase it is all negative
        private int FindSmallestValue()
        {
            int currSmallValue = 0;
            int[] intValues = GetNumbersFromInput();

            for (int i = 0; i < intValues.Length; i++)
            {
                if (intValues[i] < currSmallValue)
                {
                    currSmallValue = intValues[i];
                }
            }

            return currSmallValue;
        }

        public void FindSumOfEvenNumbers(object parameter)
        {
            int totalValue = 0;
            int[] intValues = GetNumbersFromInput();

            for (int i = 0; i < intValues.Length; i++)
            {
                if (!IsValueOdd(intValues[i]))
                {
                    totalValue += intValues[i];
                }
            }

            OutputValue = totalValue;
            IsOutputOdd = IsValueOdd(totalValue);
            IsOutputPositive = IsValuePositive(totalValue);
        }
    }
}
