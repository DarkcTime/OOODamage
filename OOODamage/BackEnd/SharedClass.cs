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
    /// <summary>
    /// Common class for Application
    /// </summary>
    class SharedClass
    {

        /// <summary>
        /// View Frame in MainPage 
        /// </summary>
        /// <param name="frame">Object frame</param>
        /// <param name="page"></param>
        public static void SetFrame(Frame frame, Page page)
        {
            frame.Content = page;
        }

        /// <summary>
        /// Open new page
        /// </summary>
        /// <param name="obj">Obj window</param>
        /// <param name="page">new Page</param>
        public static void OpenNewPage(System.Windows.DependencyObject obj, Page page)
        {
            NavigationService service = NavigationService.GetNavigationService(obj);
            service.Navigate(page);
        }

        #region MessageBox objects
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
        #endregion 
    }
}
