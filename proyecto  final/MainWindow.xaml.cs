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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathName = @"./usuarios.txt";
        public MainWindow()
        {
            InitializeComponent();
            VerificarArchivo();
        }

        private void txtusuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbUsuario.Text == "USUARIO")

            {
                txbUsuario.Text = "";

            }



        }
        private void VerificarArchivo()
        {
            try
            {
                if (!File.Exists(pathName))
                {
                    File.Create(pathName).Dispose();
                    //Ahora vamos a crear el superusuario
                    // usuarios = "nombre,tipo,usuario,password"
                    Escribir("administrador,administrador,admin,adm2");
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void Escribir(string mensaje)
        {
            StreamWriter tuberiaEscritura = File.AppendText(pathName);
            tuberiaEscritura.WriteLine(mensaje);
            tuberiaEscritura.Close();
        }

        private bool ValidarUsuario(string usuario, string password)
        {
            bool resultado = false;
            string[] datosUsuario;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datosUsuario = linea.Split(',');
                if (datosUsuario[2] == usuario && datosUsuario[3] == password)
                {
                    resultado = true;
                    break;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return resultado;
        }

        private void btningresar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string usuario = txbUsuario.Text.Trim();
                string password = txbPassword.Password.Trim();
                if (usuario != "" && password != "")
                {
                    if (ValidarUsuario(usuario, password))
                    {
                        //Datos correctos
                        //new Principal().ShowDialog();
                        login principal = new login();
                        this.Hide();
                        principal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //Datos incorrectos
                        lblMensaje.Content = "datos incorrectos";
                    }
                }
                else
                {
                    lblMensaje.Content = "Ingresa los datos";
                }
            }
            catch (Exception ex)
            {

            }

        }


        private void btncrear_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                crearCuenta CREAR = new crearCuenta();
                this.Hide();
                CREAR.ShowDialog();
                this.Close();
            }
            catch
            {

            }

        }
    }
    
}
