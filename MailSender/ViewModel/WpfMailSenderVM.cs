using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Services;
using System.Collections.ObjectModel;
using MailSender.lib.Data.Linq2SQL;

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

        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        public WpfMailSenderVM(IRecipientsDataService RecipientsDataServise)
        {
            _RecipientsDataService = RecipientsDataServise;
            UpdateData();
        }

        public void UpdateData()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsDataService.GetAll());
        }
    }
}
