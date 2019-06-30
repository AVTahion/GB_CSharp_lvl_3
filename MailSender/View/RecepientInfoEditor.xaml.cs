using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.View
{
    /// <summary>
    /// Логика взаимодействия для RecepientInfoEditor.xaml
    /// </summary>
    public partial class RecepientInfoEditor : UserControl
    {
        public RecepientInfoEditor()
        {
            InitializeComponent();
        }

        private void OnDataValidationError(object Sender, ValidationErrorEventArgs E)
        {
            var error_control = (Control)E.OriginalSource;
            if (E.Action == ValidationErrorEventAction.Added)
            {
                error_control.ToolTip = E.Error.ErrorContent.ToString();
            }
            else
            {
                error_control.ToolTip = DependencyProperty.UnsetValue;
            }
        }
    }
}
