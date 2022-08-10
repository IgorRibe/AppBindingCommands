using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand ShowMessageCommand;

        public void ShowMessage()
        {
            string dataProperty = Application.Current.Properties["dtAtual"].ToString();

            DisplayMessage = $"Boa noite {Name}. Hoje é {dataProperty}.";
        }

        public MainPageViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
        }


        private string name = string.Empty;//CTRL + R + E

        public string Name
        {
            get => name;
            set
            {

                if ( name == null )
                return;


                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));

            }
        }

        public string DisplayName => $"Nome digitado: {Name}";

        private string displayMessage = string.Empty;
        public string DisplayMessage
        {
            get => DisplayMessage;
            set
            {
                if (DisplayMessage == null)
                    return;

                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

       
    }
}
