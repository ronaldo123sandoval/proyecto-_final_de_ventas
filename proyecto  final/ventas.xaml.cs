using System;
using System.Collections.Generic;
using System.IO;
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



namespace proyecto__final
{
    /// <summary>
    /// Lógica de interacción para ventas.xaml
    /// </summary>
    public partial class ventas : Window
    {
        string pathName2 = @"D:\recibo.txt";
        string auxiliar2 = @"D:\auxiliar";
        public ventas()
        {
            InitializeComponent();
            mostrarRecibos();
            dato2.Visibility = System.Windows.Visibility.Hidden;
            enviar2.Visibility = System.Windows.Visibility.Hidden;
            cuenta.Visibility = System.Windows.Visibility.Hidden;
        }
        private void crearArchivo()
        {
            if (!File.Exists(pathName2))
            {
                File.CreateText(pathName2);
            }
        }


 
        private bool numeroReciboUnico(string numeroString)
        {
            bool resultado = true;
            try
            {
                string[] datosRecibo;
                StreamReader tuberiaLectura = File.OpenText(pathName2);
                string linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datosRecibo = linea.Split(',');
                    if (datosRecibo[0] == numeroString)
                    {
                        resultado = false;
                        break;
                    }
                    linea = tuberiaLectura.ReadLine();
                }
                tuberiaLectura.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            return resultado;
        }
        private void mostrarRecibos()
        {
            
            Recibo recibo;
            List<Recibo> listaRecibos = new List<Recibo>();
            string numero, nombre, ci, total;
            string[] datosRecibo;
            if (File.Exists(pathName2))
            {
                StreamReader tuberiaLectura = File.OpenText(pathName2);
                string linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    dato2.AppendText(linea + "\r\n");
                    datosRecibo = linea.Split(',');
                    recibo = new Recibo(datosRecibo[0], datosRecibo[1], datosRecibo[2], datosRecibo[3]);
                    listaRecibos.Add(recibo);
                    recibo = null;
                    linea = tuberiaLectura.ReadLine();
                }
                tuberiaLectura.Close();
                dgRecibos.ItemsSource = listaRecibos;
            }

        }

        private void limpiarFormulario()
        {
            txbCI.Text = "";
            txbNombre.Text = "";
            txbNumero.Text = "";
            txbTotal.Text = "";
        }

        private void DgRecibos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recibo recibo = new Recibo();
            recibo = (Recibo)dgRecibos.SelectedItem;
            if (recibo != null)
            {
                txbNumeroEliminar.Text = recibo.Numero;
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (File.Exists(pathName2))
                {
                    string numeroEliminar = txbNumeroEliminar.Text.Trim();
                    if (numeroEliminar != "")
                    {
                        string[] datosRecibos;
                        bool eliminado = false;
                        StreamReader tuberiaLectura = File.OpenText(pathName2);
                        StreamWriter tuberiaEscritura = File.AppendText(auxiliar2);
                        string linea = tuberiaLectura.ReadLine();
                        while (linea != null)
                        {
                            datosRecibos = linea.Split(',');
                            if (datosRecibos[0] == numeroEliminar)
                            {
                                eliminado = true;
                            }
                            else
                            {
                                tuberiaEscritura.WriteLine(linea);
                            }
                            linea = tuberiaLectura.ReadLine();
                        }
                        tuberiaEscritura.Close();
                        tuberiaLectura.Close();
                        //Proceso de copiado del aux al pathName
                        File.Delete(pathName2);
                        File.Move(auxiliar2, pathName2);
                        File.Delete(auxiliar2);
                        if (eliminado)
                        {
                            MessageBox.Show("El recibo se elimino con exito");
                            mostrarRecibos();
                            txbNumeroEliminar.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes ingresar el numero a eliminar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            login avanzar = new login();
            avanzar.mensaje2.Text = dato2.Text;
            avanzar.mensaje.Text = enviar2.Text;
            avanzar.mensaje2.Text = dato2.Text;
            avanzar.cuenta.Text = cuenta.Text;
            avanzar.Show();
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (File.Exists(pathName2))
                {
                    string numeroString = txbNumero.Text.Trim();
                    string nombreString = txbNombre.Text.Trim();
                    string ciString = txbCI.Text.Trim();
                    string totalString = txbTotal.Text.Trim();
                    if (numeroString != "" && nombreString != "" && ciString != "" && totalString != "")
                    {
                        int ciInt = Convert.ToInt32(ciString);
                        double totalDouble = Convert.ToDouble(totalString);
                        if (ciInt > 0 && totalDouble > 0)
                        {
                            if (numeroReciboUnico(numeroString))
                            {
                                StreamWriter tuberiaEscritura = File.AppendText(pathName2);
                                tuberiaEscritura.WriteLine(numeroString + "," + nombreString + "," + ciString + "," + totalString);
                                tuberiaEscritura.Close();
                                MessageBox.Show("Recibo se grabo con exito");
                                limpiarFormulario();
                                mostrarRecibos();
                            }
                            else
                            {
                                MessageBox.Show("Error el numero de recibo debe ser unico");
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ningun campo puede estar vacio");
                    }
                }

            }
            catch (Exception)
            {


            }

        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idModificar = txtmodificar1.Text;
                string Modificados = txtmodificar2.Text;
                string linea;
                string[] datos;
                char separador = ',';
                bool modificado = false;
                StreamReader tuberiaLectura = File.OpenText(pathName2);
                StreamWriter tuberiaEscritura = File.AppendText(auxiliar2);
                linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datos = linea.Split(separador);
                    if (idModificar == datos[0])
                    {
                        //esta es la linea que contiene la mascota que se quiere eliminar
                        modificado = true;
                        //Entonces debemos de enviar los nuevos datos y el id en el formato correcto
                        tuberiaEscritura.WriteLine(idModificar + "," + Modificados);
                    }
                    else
                    {
                        //esta mascota no es la que se quiere eliminar asi que la vamos a copiar al txt aux
                        tuberiaEscritura.WriteLine(linea);
                    }
                    linea = tuberiaLectura.ReadLine();
                }
                if (modificado)
                {
                    MessageBox.Show("La mascota se modifico con exito");
                }
                else
                {
                    MessageBox.Show("Mascota no encontrada");
                }
                tuberiaEscritura.Close();
                tuberiaLectura.Close();
                //Ahora debemos copiar todo el contenido del txt auxiliar al txt original
                // File.Delete(pathName)  borra
                // File.Move(pathName)  reemplaza el contenido
                File.Delete(pathName2);
                File.Move(auxiliar2, pathName2);
                File.Delete(auxiliar2);
                txtmodificar1.Text = "";
                txtmodificar2.Text = "";

                mostrarRecibos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la mascota " + ex.Message);
            }
        }
    }
}
