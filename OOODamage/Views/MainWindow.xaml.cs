﻿using OOODamage.BackEnd;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// genarate main Window
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                SharedClass.SetFrame(this.MainFrame, new ListClients());
            }
            catch(Exception ex)
            {
                SharedClass.MessageBoxError(ex);
            }
        }
    }
}
