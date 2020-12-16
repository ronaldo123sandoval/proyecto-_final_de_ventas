using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto__final
{
    class notas
    {
        private string[,] listaEstudiantes;

        public notas(string[,] listaEstudiantes)
        {
            this.listaEstudiantes = listaEstudiantes;
        }
        public double promedio()
        {
            double sumatoria = 0;
            for (int i = 0; i < listaEstudiantes.GetLength(0); i++)
            {
                sumatoria = sumatoria + Convert.ToDouble(listaEstudiantes[i, 3]);
            }
            return Math.Round((sumatoria / listaEstudiantes.GetLength(0)), 0);
        }
    }
}
