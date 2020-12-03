using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto__final
{
    class registro
    {
        private string id;
        private string nombre;
        private string edad;
        private string genero;
        public registro() { }
        public registro(string i, string n, string e, string g)
        {
            id = i;
            nombre = n;
            edad = e;
            genero = g;
        }
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        public string Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
