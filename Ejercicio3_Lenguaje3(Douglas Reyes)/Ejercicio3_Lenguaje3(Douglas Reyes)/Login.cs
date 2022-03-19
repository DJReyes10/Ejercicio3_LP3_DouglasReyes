using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassUsario.Entidades;
using ClassUsario.Acceso;

namespace Ejercicio3_Lenguaje3_Douglas_Reyes_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Btn__Aceptar_Click(object sender, EventArgs e)
        {
            UsuarioDA usuarioDA = new UsuarioDA();
            Usuario usuario = new Usuario();

            usuario = usuarioDA.Login(Txt_usuario.Text, Txt_contraseña.Text);

            if (usuario == null)
            {
                MessageBox.Show("Usuario ó contraseña incorrectos");

            }
            else
            {
                MessageBox.Show("Usuario Correcto");
            }
            Frm_Usuario frm_Usuario = new Frm_Usuario();
            frm_Usuario.Show();
            this.Hide();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        
        }
}
