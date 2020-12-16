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

namespace EliminarP2B
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathName = @".\cliente.txt";
        string pathNameAuxiliar = @".\auxiliar.txt";
        public MainWindow()
        {
            InitializeComponent();
            MostrarClientes();
            MostrarClientesDG();
        }

        private void MostrarClientesDG()
        {
            try
            {
                Cliente cliente;
                List<Cliente> clientes = new List<Cliente>();
                string id, nombre, fecha, temperatura, edad;
                string[] datosCliente;
                if (File.Exists(pathName))
                {                    
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    string linea = tuberiaLectura.ReadLine();
                    while (linea != null)
                    {                        
                        //txbListaClientes.AppendText(linea + "\r\n");                        
                        datosCliente = linea.Split(',');
                        id = datosCliente[0];
                        nombre = datosCliente[1];                       
                        cliente = new Cliente(id, nombre);
                        clientes.Add(cliente);                        
                        linea = tuberiaLectura.ReadLine();
                    }
                    tuberiaLectura.Close();
                    dgClientes.ItemsSource = clientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los clientes " + ex.Message);
                Console.WriteLine(ex);
            }
        }

        private void MostrarClientes()
        {
            try
            {
                if (File.Exists(pathName))
                {
                    txbListaClientes.Text = "";
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    string linea = tuberiaLectura.ReadLine();
                    while (linea !=null)
                    {
                        txbListaClientes.AppendText(linea + "\r\n");
                        linea = tuberiaLectura.ReadLine();
                    }
                    tuberiaLectura.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los clientes " + ex.Message);
                Console.WriteLine(ex);
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(pathName))
                {
                    string idCliente = txbIdCliente.Text.Trim();
                    string cliente = txbCliente.Text.Trim();
                    if (cliente!="" && idCliente!="")
                    {
                        if (ValidarId(idCliente))
                        {
                            //el id es unico
                            StreamWriter tuberiaEscritura = File.AppendText(pathName);
                            tuberiaEscritura.WriteLine(idCliente+","+cliente);
                            tuberiaEscritura.Close();
                            MessageBox.Show("El cliente se grabo con exito");
                            txbCliente.Text = "";
                            txbIdCliente.Text = "";
                            MostrarClientes();
                            MostrarClientesDG();
                        }
                        else
                        {
                            MessageBox.Show("El id debe de ser unico");
                        }                       
                    }
                    else
                    {
                        MessageBox.Show("No se permite vacio");
                    }
                }
                else
                {
                    //crear el archivo
                    File.CreateText(pathName).Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }            
        }

        private bool ValidarId(string idCliente)
        {
            bool respuesta = true;
            string[] datosSeparados;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string linea = tuberiaLectura.ReadLine();
            while (linea !=null)
            {
                datosSeparados = linea.Split(',');
                if (idCliente == datosSeparados[0])
                {
                    respuesta = false;
                    break;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return respuesta;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ciEliminar = txbCiEliminar.Text;
                if (ciEliminar!="")
                {
                    string linea;
                    string[] datosCliente;
                    char separador = ',';
                    bool eliminado = false;                    
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                    linea = tuberiaLectura.ReadLine();
                    while (linea!=null)
                    {
                        datosCliente = linea.Split(separador);
                        if (ciEliminar!=datosCliente[0])
                        {
                            tuberiaEscritura.WriteLine(linea);
                        }
                        else
                        {
                            eliminado = true;
                        }
                        linea = tuberiaLectura.ReadLine();
                    }
                    tuberiaEscritura.Close();
                    tuberiaLectura.Close();

                    //vamos a copiar todo el contenido del auxiliar en el original
                    File.Delete(pathName);
                    File.Move(pathNameAuxiliar, pathName);
                    File.Delete(pathNameAuxiliar);
                    if (eliminado)
                    {
                        MessageBox.Show("El cliente se elimino con exito");
                        MostrarClientes();
                        MostrarClientesDG();
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe");
                    }
                    txbCiEliminar.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pemite vacio");
                }

            }
            catch (Exception)
            {
                
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idModificar = txbIdCliente.Text;
                if (idModificar != "")
                {
                    string linea;
                    string[] datosCliente;
                    char separador = ',';
                    bool modificar = false;
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                    linea = tuberiaLectura.ReadLine();
                    while (linea != null)
                    {
                        datosCliente = linea.Split(separador);
                        if (idModificar != datosCliente[0])
                        {
                            tuberiaEscritura.WriteLine(linea);
                        }
                        else
                        {
                            modificar = true;
                            string clienteModificado = txbCliente.Text;
                            tuberiaEscritura.WriteLine(idModificar + "," + clienteModificado);
                        }
                        linea = tuberiaLectura.ReadLine();
                    }
                    tuberiaEscritura.Close();
                    tuberiaLectura.Close();

                    //vamos a copiar todo el contenido del auxiliar en el original
                    File.Delete(pathName);
                    File.Move(pathNameAuxiliar, pathName);
                    File.Delete(pathNameAuxiliar);
                    if (modificar)
                    {
                        MessageBox.Show("El cliente se modifico con exito");
                        MostrarClientes();
                        txbIdCliente.Text = "";
                        txbCliente.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe");
                    }                    
                }
                else
                {
                    MessageBox.Show("No se pemite vacio");
                }

            }
            catch (Exception)
            {

            }
        }

        private void DgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClientes.SelectedItem !=null)
            {
                Cliente cliente = new Cliente();
                cliente = (Cliente)dgClientes.SelectedItem;
                txbCiEliminar.Text = cliente.Id;
            }
           
        }
    }
}
