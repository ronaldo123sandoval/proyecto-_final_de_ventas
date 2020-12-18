namespace proyecto__final
{
    class Recibo
    {
            private string numero;
            private string nombre;
            private string ci;
            private string total;
            public Recibo()
            {

            }
            public Recibo(string numero, string nombre, string ci, string total)
            {
                this.ci = ci;
                this.nombre = nombre;
                this.total = total;
                this.Numero = numero;
    
            }
            public string Numero
            {
                get { return numero; }
                set { numero= value; }
            }
            public string NOMBRE
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