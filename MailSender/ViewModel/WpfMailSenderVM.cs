using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ViewModel
{
    public class WpfMailSenderVM : ViewModelBase
    {
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
    }
}
