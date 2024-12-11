using System;
using System.Collections.ObjectModel;
using JackalChat.Core;
using JackalChat.MVVM.Model;

namespace JackalChat.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */

        public RelayCommand SendCommand { get; set; }


        private ContactModel _selectedContact;
            
        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged(); }
        }



        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }



        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    IsFirstMessage = false
                });

                Message = "";
            });

            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    Messages.Add(new MessageModel
                    {
                        Username = $"Person ${i + 1}",
                        UsernameColor = "#4098ff",
                        ImageSource = "https://t3.ftcdn.net/jpg/08/20/75/34/360_F_820753420_Nqjb8USaj0J7K82Uo6yZLhCv4roZFBj7.jpg",
                        Message = $"Message {j + 1}",
                        Time = DateTime.Now,
                        IsNativeOrigin = false,
                        IsFirstMessage = true
                    });
                }

                Contacts.Add(new ContactModel
                {
                    Username = $"Person {i + 1}",
                    ImageSource = "https://t3.ftcdn.net/jpg/08/20/75/34/360_F_820753420_Nqjb8USaj0J7K82Uo6yZLhCv4roZFBj7.jpg",
                    Messages = Messages
                });
            }
        }
    }
}
