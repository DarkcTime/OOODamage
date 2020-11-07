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
    /// Interaction logic for AddOrEditClient.xaml
    /// </summary>
    public partial class AddOrEditClient : Page
    {
        Client Client;       
        private string addStr = "Добавить", editStr = "Сохранить";
        Repositories.ClientRep clientRep = new Repositories.ClientRep();

        public AddOrEditClient()
        {
            InitializeComponent();
            Client = new Client();
            this.DataContext = Client;
           
            MakeLabels(addStr);
            this.Client.BirhDate = DateTime.Parse("08.08.2020");
        }

        public AddOrEditClient(Client client)
        {
            InitializeComponent();            
            Client = client;
            this.DataContext = Client;
          
            MakeLabels(editStr);
            SetGenderDisplay(); 
            
        }



        private void MakeLabels(string type)
        {
            this.BtnEditOrAdd.Content = type; 
            if(type == addStr)
            {
                this.TextBlockEditOrAddClient.Text = $"Добавление клиента";
            }
            else
            {
                this.TextBlockEditOrAddClient.Text = $"Изменение клиента";
            }
        }


        private void EditOrAddClick(object sender, RoutedEventArgs e)
        {
            SetGenderClient();
            if(this.BtnEditOrAdd.Content.ToString() == addStr)
            {
                clientRep.AddClient(Client);
                SharedClass.MessageBoxInformation("Клиент успешно добавлен");
            }
            else
            {
                clientRep.EditClient(Client);
                SharedClass.MessageBoxInformation("Данные о клиенте успешно отредактировны");
            }
            SharedClass.OpenNewPage(this, new ListClients());
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            SharedClass.OpenNewPage(this, new ListClients());   
        }
        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            string path = Utilities.SelectImage();
            if (path != "null")
                this.ImgClient.Source = new BitmapImage(new Uri(path, UriKind.Relative)); ; 
                SetPhotoForClient(path); 
            
        }

        private void SetPhotoForClient(string path)
        {
            Client.Photo = path; 

        }
        private void SetGenderDisplay()
        {
            if (this.Client.IdGender == "м") this.Man.IsChecked = true;
            else this.Woman.IsChecked = true; 
        }
        private void SetGenderClient()
        {
            if (IsMan()) Client.IdGender = "м";
            else Client.IdGender = "ж";
        }
        private bool IsMan()
        {
            return this.Man.IsChecked == true;
        }

       
    }
}
