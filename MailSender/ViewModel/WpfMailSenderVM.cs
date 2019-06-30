using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Services;
using System.Collections.ObjectModel;
using MailSender.lib.Data.Linq2SQL;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace MailSender.ViewModel
{
    public class WpfMailSenderVM : ViewModelBase
    {
        private readonly IRecipientsDataService _RecipientsDataService;
        private string _Title = "Помошник спамера";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов спамить!";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private int _MainTabControlSelectedIndex;

        public int MainTabControlSelectedIndex
        {
            get => _MainTabControlSelectedIndex;
            set => Set(ref _MainTabControlSelectedIndex, value);
        }

        private int _MainTabControlItemCount = 4;

        public int MainTabControlItemCount
        {
            get => _MainTabControlItemCount;
        }

        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        private Recipient _CurrentRecipient;

        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }

        public ICommand UpdateDataCommand { get; }

        public ICommand CreateRecipientCommand { get; }

        public ICommand SaveRecipientCommand { get; }

        public ICommand AppExitCommand { get; }

        public ICommand TabControlLeft { get; }

        public ICommand TabControlRight { get; }

        public WpfMailSenderVM(IRecipientsDataService RecipientsDataServise)
        {
            _RecipientsDataService = RecipientsDataServise;
            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, CanUpdateDataCommandExecuted);
            CreateRecipientCommand = new RelayCommand(OnCreateRecipientExecuted, CanCreateRecipientExecuted);
            SaveRecipientCommand = new RelayCommand<Recipient>(OnSaveRecipientExecuted, CanSaveRecipientExecuted);
            AppExitCommand = new RelayCommand(OnAppExitCommand, () => true, true);
            TabControlLeft = new RelayCommand(OnTabControlLeft, CanTabControlLeft);
            TabControlRight = new RelayCommand(OnTabControlRight, CanTabControlRight);
        }

        private void OnUpdateDataCommandExecuted()
        {
            UpdateData();
        }

        private bool CanUpdateDataCommandExecuted() => true;

        private void OnCreateRecipientExecuted()
        {
            var new_recipient = new Recipient()
            {
                Name = "New_Recipient",
                Address = "recipient@server.net"
            };
            _RecipientsDataService.Create(new_recipient);
            _Recipients.Add(new_recipient);
            CurrentRecipient = new_recipient;
        }

        private bool CanCreateRecipientExecuted() => true;

        private void OnSaveRecipientExecuted(Recipient recipient)
        {
            _RecipientsDataService.Update(recipient);
        }

        private bool CanSaveRecipientExecuted(Recipient recipient) => recipient != null;

        private void OnAppExitCommand()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnTabControlLeft()
        {
            MainTabControlSelectedIndex--;
        }

        private bool CanTabControlLeft() => MainTabControlSelectedIndex > 0;

        private void OnTabControlRight()
        {
            MainTabControlSelectedIndex++;
        }

        private bool CanTabControlRight() => MainTabControlSelectedIndex < MainTabControlItemCount;

        public void UpdateData()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsDataService.GetAll());
        }
    }
}
