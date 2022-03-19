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
    public partial class Frm_Usuario : Form
    {
        public Frm_Usuario()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            Dtp_Usuario.DataSource = usuarioDA.ListarUsuarios();
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }
        private void HabilitarControles()
        {
            Txt_Usuario.Enabled = true;
            
            Txt_Contraseña.Enabled = true;
            

            Btn_Nuevo.Enabled = false;
            Btn_Guardar.Enabled = true;
            Btn_Salir.Enabled = true;


        }

        private void DesabilitarControles()
        {
            Txt_Usuario.Enabled = false;

            Txt_Contraseña.Enabled = false;


            Btn_Nuevo.Enabled = true;
            Btn_Guardar.Enabled = false;
            Btn_Salir.Enabled = false;


        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            user.NombreUsu = Txt_Usuario.Text;
            user.Contraseña = Txt_Contraseña.Text;


            if (operacion == "Nuevo")
            {
                bool inserto = usuarioDA.InsertarUsuario(user);

                if (inserto)
                {
                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Crear");
                }
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
        }
    }
    }
