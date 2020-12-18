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
    /// Lógica de interacción para informes.xaml
    /// </summary>
    public partial class informes : Window
    {
        public informes()
        {
            InitializeComponent();
        }

        private void btnvolver_Click(object sender, RoutedEventArgs e)
        {
            login avanzar = new login();
            avanzar.Show();
            this.Close();

        }
    }
}
