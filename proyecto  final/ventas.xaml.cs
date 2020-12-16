using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Navigation;



namespace proyecto__final
{
    /// <summary>
    /// Lógica de interacción para ventas.xaml
    /// </summary>
    public partial class ventas : Window
    {
        public ventas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            datagrid1.Items.Clear();
            int filas = int.Parse(textbox1.Text);
            string[,] listaEstudiantes = new string[filas, 4];
            notas objeto = new notas(listaEstudiantes);
            DataGridTextColumn examen = new DataGridTextColumn();
            examen.Header = "Nombre";
            examen.Binding = new Binding("nota");
            datagrid1.Columns.Add(examen);
            DataGridTextColumn examen2 = new DataGridTextColumn();
            examen2.Header = "Primer Parcial ";
            examen2.Binding = new Binding("nota1");
            datagrid1.Columns.Add(examen2);
            DataGridTextColumn examen3 = new DataGridTextColumn();
            examen3.Header = "Segundo Parcial";
            examen3.Binding = new Binding("nota2");
            datagrid1.Columns.Add(examen3);
            DataGridTextColumn examen4 = new DataGridTextColumn();
            examen4.Header = "Promedio";
            examen4.Binding = new Binding("nota3");
            datagrid1.Columns.Add(examen4);

            for (int i = 0; i < listaEstudiantes.GetLength(0); i++)
            {
                for (int j = 0; j < (listaEstudiantes.GetLength(1) - 1); j++)
                {
                    if (j == 0)
                    {
                        listaEstudiantes[i, j] = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el" + (i + 1) + " nombre del estudiante ");
                    }
                    else
                    {
                        listaEstudiantes[i, j] = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la " + j + " Nota del  primer examen");
                    }
                }
            }
            double fila, promedio;
            for (int i = 0; i < listaEstudiantes.GetLength(0); i++)
            {
                fila = 0;
                promedio = 0;
                for (int j = 1; j < listaEstudiantes.GetLength(1); j++)
                {
                    fila += Convert.ToDouble(listaEstudiantes[i, j]);
                    promedio = Math.Round(fila + 0);
                }
                listaEstudiantes[i, 3] = Convert.ToString(promedio);
            }
            for (int i = 0; i < listaEstudiantes.GetLength(0); i++)
            {
                datagrid1.Items.Add(new { nota = listaEstudiantes[i, 0], nota1 = listaEstudiantes[i, 1], nota2 = listaEstudiantes[i, 2], nota3 = listaEstudiantes[i, 3] });
            }
        }
    }
}
