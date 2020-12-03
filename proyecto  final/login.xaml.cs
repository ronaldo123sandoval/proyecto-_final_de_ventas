using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace proyecto__final
{
    /// <summary>
    /// Lógica de interacción para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }


        private void btnsalir_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("´¿ESTAS SEGURO QUE DESEA SALIR?", "", MessageBoxButton.YesNo );
    

            if (MessageBoxResult.Yes == MessageBoxResult.No)
            {

            }
            else
            {
                this.Close();
            }
      
        }

        private void btnquienes_Click(object sender, RoutedEventArgs e)
        {
            informacion siguiente = new informacion();
            siguiente.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            productos siguiente = new productos();
            siguiente.Show();
            this.Close();

        }
    }
  }
    


