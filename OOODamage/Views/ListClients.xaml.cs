using OOODamage.BackEnd;
using OOODamage.Models;
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

namespace OOODamage.Views
{
    /// <summary>
    /// Interaction logic for ListClients.xaml
    /// </summary>
    public partial class ListClients : Page 
    {
        //create object Repositories
        Repositories.DisplayClientRep displayClientRep = new Repositories.DisplayClientRep();
        Repositories.ClientRep clientRep = new Repositories.ClientRep();
        
        public ListClients()
        {
            try
            {
                InitializeComponent();
                UpdateList();
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex); 
            }
                         
        }

        #region LoadPage
        private void UpdateList()
        {
            try
            {
                List<DisplayClient> displayClients = new List<DisplayClient>();
                displayClients = null;
                displayClients = displayClientRep.GetDisplayClients(this.ComboBoxGender.SelectedIndex, this.TxtSearch.Text);
                this.MainDataGrid.ItemsSource = displayClients;
                SetTextBlockCountRecords(displayClientRep.CountRecords(displayClients));
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex);
            }
        }      
        private void SetTextBlockCountRecords(int count)
        {
            this.TextBlockCountRecords.Text = $"Количество записей: {count}";
        }
        #endregion

        #region UI Events
        private void AddClick(object sender, RoutedEventArgs e)
        {
            SharedClass.OpenNewPage(this, new AddOrEditClient());
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            try
            {

                if (IsSelectedClient())
                {
                    Client client = displayClientRep.GetClient(GetSelectedDisplayClient());
                    SharedClass.OpenNewPage(this, new AddOrEditClient(client));
                }
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex);
            }
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SharedClass.MessageBoxQuestion("Вы уверены что хотите удалить клиента?") == MessageBoxResult.No)
                    return;

                if (IsSelectedClient())
                {
                    Client client = displayClientRep.GetClient(GetSelectedDisplayClient());
                    clientRep.RemoveClient(client);
                    UpdateList();
                    SharedClass.MessageBoxInformation("Клиент успешно удален");
                }
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex);    
            }
           
        }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
        private void ComboBoxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        #endregion

        private bool IsSelectedClient()
        {
            if (this.MainDataGrid.SelectedItem is DisplayClient)
            {
                return true;
            }
            else
            {
                SharedClass.MessageBoxWarning("Выберите клиента в таблице");
                return false;
            }
        }
        private DisplayClient GetSelectedDisplayClient()
        {
            return (DisplayClient)this.MainDataGrid.SelectedItem;
        }


       

    }
}
