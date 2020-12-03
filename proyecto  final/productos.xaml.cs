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
        string pathName = @"D:\mascota.txt";
        string pathNameAuxiliar = @"D:\VIDEOS DE RONALDO\Programacion\proyecto\auxiliar.txt";
        public productos()
        {
            InitializeComponent();
            MostrarMascotas();

        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            login principal = new login();
            this.Hide();
            principal.ShowDialog();
            this.Close();

        }
        private void CrearArchivoMascota()
        {
            File.CreateText(pathName);
            File.CreateText(pathNameAuxiliar);
            StreamWriter tuberiaEscritura = File.AppendText(pathName);
            StreamWriter tuberiaLectura = File.AppendText(pathNameAuxiliar);
        }

        private void MostrarMascotas()
        {
            try
            {
                txbListaMascotas.Text = "";
                if (File.Exists(pathName))
                {
                    string fila;
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    fila = tuberiaLectura.ReadLine();
                    while (fila != null)
                    {
                        txbListaMascotas.AppendText(fila + "\r\n");
                        fila = tuberiaLectura.ReadLine();
                    }
                    tuberiaLectura.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnmodificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idMascotaModificar = txtguardar.Text;
                string datosModificados = txtmodificar.Text;
                string linea;
                string[] datosMascota;
                char separador = ',';
                bool modificado = false;
                StreamReader tuberiaLectura = File.OpenText(pathName);
                StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datosMascota = linea.Split(separador);
                    if (idMascotaModificar == datosMascota[0])
                    {
                        //esta es la linea que contiene la mascota que se quiere eliminar
                        modificado = true;
                        //Entonces debemos de enviar los nuevos datos y el id en el formato correcto
                        tuberiaEscritura.WriteLine(idMascotaModificar + "," + datosModificados);
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
                    MessageBox.Show("La Factura se modifico con exito");
                }
                else
                {
                    MessageBox.Show("Factura no  se encontro");
                }
                tuberiaEscritura.Close();
                tuberiaLectura.Close();
                //Ahora debemos copiar todo el contenido del txt auxiliar al txt original
                // File.Delete(pathName)  borra
                // File.Move(pathName)  reemplaza el contenido
                File.Delete(pathName);
                File.Move(pathNameAuxiliar, pathName);
                File.Delete(pathNameAuxiliar);
                txtguardar.Text = "";
                txtmodificar.Text = "";
                MostrarMascotas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la  factura " + ex.Message);
            }

        }

        private void btnguardar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (File.Exists(pathName))
                {
                    string idMascota = txtguardar.Text.Trim();
                    string datosMascota = txtmodificar.Text.Trim();
                    if (datosMascota != "" && idMascota != "")
                    {
                        if (ValidarId(idMascota))
                        {
                            //si es verdad no existen mascotas con ese idMascota
                            StreamWriter tuberiaEscritura = File.AppendText(pathName);
                            tuberiaEscritura.WriteLine(idMascota + "," + datosMascota );
                            tuberiaEscritura.Close();
                            MessageBox.Show("Venta se registro con exito");
                            txtmodificar.Text = "";
                            MostrarMascotas();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe una facutara con ese id, pruebe con otro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se permite vacio");
                    }
                }
                else
                {
                    CrearArchivoMascota();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }
        private bool ValidarId(string idMascota)
        {
            bool respuesta = true;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string[] datos;
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datos = linea.Split(',');
                if (datos[0] == idMascota)
                {
                    //ya hay un id con ese valor
                    respuesta = false;
                    break;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return respuesta;
        }

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string idMascotaEliminar = txteliminar.Text;
                string linea;
                string[] datosMascota;
                char separador = ',';
                bool eliminado = false;
                StreamReader tuberiaLectura = File.OpenText(pathName);
                StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datosMascota = linea.Split(separador);
                    if (idMascotaEliminar == datosMascota[0])
                    {
                        //esta es la linea que contiene la mascota que se quiere eliminar
                        eliminado = true;
                    }
                    else
                    {
                        //esta mascota no es la que se quiere eliminar asi que la vamos a copiar al txt aux
                        tuberiaEscritura.WriteLine(linea);
                    }
                    linea = tuberiaLectura.ReadLine();
                }
                if (eliminado)
                {
                    MessageBox.Show("La Factura se elimino con exito");
                }
                else
                {
                    MessageBox.Show("Factura no encontrada, no se elimino");
                }
                tuberiaEscritura.Close();
                tuberiaLectura.Close();
                //Ahora debemos copiar todo el contenido del txt auxiliar al txt original
                // File.Delete(pathName)  borra
                // File.Move(pathName)  reemplaza el contenido
                File.Delete(pathName);
                File.Move(pathNameAuxiliar, pathName);
                File.Delete(pathNameAuxiliar);
                MostrarMascotas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex.Message);
            }

        }

        private void btnBUSCAR_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombreMascota = txtBUSCAR.Text;
                string linea;
                string[] datosMascota;
                char separador = ',';
                bool encontrado = false;
                StreamReader tuberiaLectura = File.OpenText(pathName);
                linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datosMascota = linea.Split(separador);
                    if (datosMascota[0] == nombreMascota)
                    {
                        MessageBox.Show("ID encontrado\nNNOMBRE:: " +
                            datosMascota[0] + "\nCIUDAD: " + datosMascota[1] +
                            "\nPRODUCTO: " + datosMascota[2] +"\nCANTIDAD:"+datosMascota[3]+"\nPRECIO:"+datosMascota[4]+"\nEMPRESA:"+datosMascota[5]);

                        encontrado = true;
                    }
                    linea = tuberiaLectura.ReadLine();
                }
                if (!encontrado)
                {
                    MessageBox.Show("EL ID no se encontro " + nombreMascota);
                }
                txtBUSCAR.Text = "";
                tuberiaLectura.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la busqueda");
            }
        }
    }
}
