using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.Linq2SQL;
using MailSender.lib.Services;
using MailSender.lib.Services.Linq2SQL;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new MailSenderDBContext());
            SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceLinq2SQL>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WpfMailSenderVM>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public WpfMailSenderVM WpfMailSenderViewModel => ServiceLocator.Current.GetInstance<WpfMailSenderVM>();

        public static void Cleanup()
        {
        }
    }
}