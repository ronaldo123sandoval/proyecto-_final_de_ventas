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
    /// Lógica de interacción para informacion.xaml
    /// </summary>
    public partial class informacion : Window
    {
        public informacion()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            login principal = new login();
            this.Hide();
            principal.ShowDialog();
            this.Close();


        }
    }
}
