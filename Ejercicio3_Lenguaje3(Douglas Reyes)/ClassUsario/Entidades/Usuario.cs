using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUsario.Entidades
{
    public class Usuario
    {
        public string NombreUsu { get; set; }
        public string Contraseña { get; set; }

        public Usuario()
        {
        }

        public Usuario(string nombreUsu, string contraseña)
        {
            NombreUsu = nombreUsu;
            Contraseña = contraseña;
        }
    }
}
