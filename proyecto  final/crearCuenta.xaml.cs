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
    /// Lógica de interacción para crearCuenta.xaml
    /// </summary>
    public partial class crearCuenta : Window
    {
        public crearCuenta()
        {
            InitializeComponent();
        }

        private void btnCREAR_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string nombre = txbNombre.Text;
                string tipo = txbTipo.Text;
                string usuario = txbUsuario.Text;
                string password = txbPassword.Text;
                MainWindow login = new MainWindow();
                login.Escribir(nombre + "," + tipo + "," + usuario + "," + password);
                MessageBox.Show("Usuario almacenado con exito");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSALIR_Click(object sender, RoutedEventArgs e)
        {
            MainWindow principal = new MainWindow();
            this.Hide();
            principal.ShowDialog();
            this.Close();
        }
    }
}
