using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto__final
{
    class Producto
    {

        private string numero;
        private string nombre;
        private string ci;
        private string total;
        public Producto()
        {

        }
        public Producto(string numero, string nombre, string ci, string total)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.total = total;
            this.numero = numero;
        }
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }
        public string Total
        {
            get { return total; }
            set { total = value; }
        }




    }
}
