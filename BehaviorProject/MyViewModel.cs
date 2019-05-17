using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BehaviorProject
{
    public class MyViewModel : ViewModelBase
    {
        private string _switchValue;

        public string SwitchValue
        {
            get { return _switchValue; }
            set { Set(ref _switchValue, value); }
        }

        public ICommand MySwitchCommand { get; set; }

        public MyViewModel()
        {
            MySwitchCommand = new RelayCommand<bool>((value) => ExecuteSwitchCommand(value));
        }

        private void ExecuteSwitchCommand(bool value)
        {
            SwitchValue = value.ToString();
        }
    }
}
