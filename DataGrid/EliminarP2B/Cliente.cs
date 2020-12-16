using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliminarP2B
{
    class Cliente
    {
        private string id;
        private string edad;
        private string temperatuta;
        private string fecha;
        private string nombre;

        public Cliente()
        {

        }
        public Cliente(string id,string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Cliente(string i,string n,string f,string t,string e)
        {
            id = i;
            nombre = n;
            fecha = f;
            temperatuta = t;
            edad = e;
        }     

        public string Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Edad
        {
            get { return edad; }
            set { edad = value; }
        }        

        public string Temperatuta
        {
            get { return temperatuta; }
            set { temperatuta = value; }
        }       

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }        

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
