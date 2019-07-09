using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services;
using MailSender.lib.Services.InMemory;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new MailSenderDBContext());
            SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceInMemory>();
            SimpleIoc.Default.Register<ISenderDataService, SendersDataInMemory>();
            SimpleIoc.Default.Register<IServersDataService, ServersDataInMemory>();
            SimpleIoc.Default.Register<IMailMessagesDataService, MailMessagesDataInMemory>();
            SimpleIoc.Default.Register<IMailSenderService, SmtpMailSenderService>();

            //SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WpfMailSenderVM>();
        }

        //public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public WpfMailSenderVM WpfMailSenderViewModel => ServiceLocator.Current.GetInstance<WpfMailSenderVM>();

        public static void Cleanup()
        {
        }
    }
}