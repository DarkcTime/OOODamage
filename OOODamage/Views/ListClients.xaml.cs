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
        Repositories.DisplayClientRep displayClientRep = new Repositories.DisplayClientRep();
        Repositories.ClientRep clientRep = new Repositories.ClientRep();
        
        public ListClients()
        {
            InitializeComponent();
            UpdateList();             
        }

        private void UpdateList()
        {
            List<DisplayClient> displayClients = new List<DisplayClient>();
            displayClients = null;
            displayClients = displayClientRep.GetDisplayClients(this.ComboBoxGender.Text, this.TxtSearch.Text);
            this.MainDataGrid.ItemsSource = displayClients;
            SetTextBlockCountRecords(displayClientRep.CountRecords(displayClients));
        }
      
        private void SetTextBlockCountRecords(int count)
        {
            this.TextBlockCountRecords.Text = $"Количество записей: {count}";
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();   
        }

        private void ComboBoxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList(); 
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (IsSelectedClient())
            {
                Client client = displayClientRep.GetClient(GetSelectedDisplayClient());
                SharedClass.OpenNewPage(this, new AddOrEditClient(client));
            }
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (IsSelectedClient())
            {
                Client client = displayClientRep.GetClient(GetSelectedDisplayClient());
                clientRep.RemoveClient(client);
                UpdateList();
                SharedClass.MessageBoxInformation("Клиент успешно удален");            
            }
        }
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


        private void AddClick(object sender, RoutedEventArgs e)
        {
            SharedClass.OpenNewPage(this, new AddOrEditClient());
        }

    }
}
