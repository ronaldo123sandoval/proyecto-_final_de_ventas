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
    /// Lógica de interacción para productos.xaml
    /// </summary>
    public partial class productos : Window


    {
        string pathName1 = @"D:\recibo1.txt";
        string auxiliar1= @"D:\auxiliar1";
        public productos()
        {
            
            InitializeComponent();
            crearArchivo();
            mostrarRecibos();
            dato1.Visibility = System.Windows.Visibility.Hidden;
        }
        private void crearArchivo()
        {
            if (!File.Exists(pathName1))
            {
                File.CreateText(pathName1);
            }
        }
        private bool numeroReciboUnico(string numeroString)
        {
            bool resultado = true;
            try
            {
                string[] datosProductos;
                StreamReader tuberiaLectura1 = File.OpenText(pathName1);
                string linea = tuberiaLectura1.ReadLine();
                while (linea != null)
                {
                    datosProductos = linea.Split(',');
                    if (datosProductos[0] == numeroString)
                    {
                        resultado = false;
                        break;
                    }
                    linea = tuberiaLectura1.ReadLine();
                }
                tuberiaLectura1.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            return resultado;
        }

        private void mostrarRecibos()
        {
            Producto producto;
            List<Producto> lista = new List<Producto>();
            string numero, nombre, ci, total, cantidad;
            string[] datos;
            if (File.Exists(pathName1))
            {
                StreamReader tuberiaLectura1 = File.OpenText(pathName1);
                string lineas = tuberiaLectura1.ReadLine();
                while (lineas != null)
                {
                    dato1.AppendText(lineas+ "\r\n");
                    datos = lineas.Split(',');
                    producto = new Producto(datos[0], datos[1], datos[2], datos[3]);
                    lista.Add(producto);
                    producto = null;
                    lineas = tuberiaLectura1.ReadLine();
                }
                tuberiaLectura1.Close();
                dgproducto.ItemsSource = lista;
            }
        }
        private void limpiarFormulario()
        {
            txtid.Text = "";
            txtnombre.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";
        }

        private void BTNGUARDAR_Click(object sender, RoutedEventArgs e)
        {

            try
            {
               
                
                
                

                if (File.Exists(pathName1))
                {
                    string numeroString = txtid.Text.Trim();
                    string nombreString = txtnombre.Text.Trim();
                    string ciString = txtproducto.Text.Trim();
                    string totalString = txtprecio.Text.Trim();


                    if (numeroString != "" && nombreString != "" && ciString != "" && totalString != "" )
                    {
                        int ciInt = Convert.ToInt32(ciString);
                        double totalDouble = Convert.ToDouble(totalString);
                        if (ciInt > 0 && totalDouble > 0)
                        {
                            if (numeroReciboUnico(numeroString))
                            {
                                StreamWriter tuberiaEscritura = File.AppendText(pathName1);
                                tuberiaEscritura.WriteLine(numeroString + "," + nombreString + "," + ciString + "," + totalString );
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

        private void BTNELIMINAR_Click(object sender, RoutedEventArgs e)
        {


            try
            {

                if (File.Exists(pathName1))
                { 
                    string numeroEliminar = txteliminar.Text.Trim();
                    if (numeroEliminar != "")
                    {
                        string[] datosRecibos;
                        bool eliminado = false;
                        StreamReader tuberiaLectura1 = File.OpenText(pathName1);
                        StreamWriter tuberiaEscritura1 = File.AppendText(auxiliar1);
                        string linea = tuberiaLectura1.ReadLine();
                        while (linea != null)
                        {
                            datosRecibos = linea.Split(',');
                            if (datosRecibos[0] == numeroEliminar)
                            {
                                eliminado = true;
                            }
                            else
                            {
                                tuberiaEscritura1.WriteLine(linea);
                            }
                            linea = tuberiaLectura1.ReadLine();
                        }
                        tuberiaEscritura1.Close();
                        tuberiaLectura1.Close();
                        //Proceso de copiado del aux al pathName
                        File.Delete(pathName1);
                        File.Move(auxiliar1, pathName1);
                        File.Delete(auxiliar1);
                        if (eliminado)
                        {
                            MessageBox.Show("El recibo se elimino con exito");
                            mostrarRecibos();
                            txteliminar.Text = "";
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

        private void dgproducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Producto producto = new Producto();
            producto = (Producto)dgproducto.SelectedItem;
            if (producto != null)
            {
                txtid.Text = producto.Numero;
            }
        }

        private void btnvolver_Click(object sender, RoutedEventArgs e)
        {
            login avanzar = new login();
            avanzar.mensaje.Text = dato1.Text;
            avanzar.mensaje2.Text = dato2.Text;
            avanzar.cuenta.Text = cuenta1.Text;

     
   
            avanzar.Show();
            this.Close();


        }

        private void MODIFICAR_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idModificar = txtmodificar.Text;
                string Modificados = txttexto.Text;
                string linea;
                string[] datos;
                char separador = ',';
                bool modificado = false;
                StreamReader tuberiaLectura = File.OpenText(pathName1);
                StreamWriter tuberiaEscritura = File.AppendText(auxiliar1);
                linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datos= linea.Split(separador);
                    if (idModificar == datos[0])
                    {
                        //esta es la linea que contiene la mascota que se quiere eliminar
                        modificado = true;
                        //Entonces debemos de enviar los nuevos datos y el id en el formato correcto
                        tuberiaEscritura.WriteLine(idModificar + "," +Modificados);
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
                File.Delete(pathName1);
                File.Move(auxiliar1, pathName1);
                File.Delete(auxiliar1);
                txtid.Text = "";
                txtnombre.Text = "";
                txtproducto.Text = "";
                txtprecio.Text = "";
                txtmodificar.Text = "";
                txttexto.Text = "";

                mostrarRecibos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la mascota " + ex.Message);
            }
        }
    }
}


