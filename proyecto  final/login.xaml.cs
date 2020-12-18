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
            cuenta.Visibility = System.Windows.Visibility.Hidden;
            mensaje.Visibility = System.Windows.Visibility.Hidden;
            mensaje2.Visibility = System.Windows.Visibility.Hidden;
            enviar2.Visibility = System.Windows.Visibility.Hidden;
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
            siguiente.dato2.Text = mensaje2.Text;
            siguiente.cuenta1.Text = cuenta.Text;
            siguiente.Show();
            this.Close();

        }

        private void btnventas_Click(object sender, RoutedEventArgs e)
        {
            ventas siguiente = new ventas();
            siguiente.enviar2.Text=mensaje.Text;
            siguiente.cuenta.Text = cuenta.Text;
            siguiente.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            informes avanzar = new  informes();
            avanzar.txtdatos1.Text = mensaje.Text;
            avanzar.txtdatos2.Text = mensaje2.Text;
            avanzar.cuenta.Content = cuenta.Text;
           
            avanzar.Show();
            this.Close();
        }
    }
  }
    


