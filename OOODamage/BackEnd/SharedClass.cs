using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OOODamage.BackEnd
{
    class SharedClass
    {
        public static void SetFrame(Frame frame, Page page)
        {
            frame.Content = page;
        }

        public static void OpenNewPage(System.Windows.DependencyObject obj, Page page)
        {
            NavigationService service = NavigationService.GetNavigationService(obj);
            service.Navigate(page);
        }

        public static void MessageBoxError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MessageBoxError(string message, string title = "Ошибка")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MessageBoxWarning(string message, string title = "Проверьте данные")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void MessageBoxInformation(string message, string title = "Успешно")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult MessageBoxQuestion(string message, string title = "Вопрос")
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result;
        }
    }
}
