using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassUsario.Entidades;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClassUsario.Acceso
{
    public class UsuarioDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=usuario_ejer3; Uid=root; Pwd=Reyesalvares10@;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string nombreUsu, string contraseña)
        {
            Usuario user = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE NombreUsu = @NombreUsu AND Contraseña = @Contraseña;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("NombreUsu", nombreUsu);
                cmd.Parameters.AddWithValue("Contraseña", contraseña);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuario();
                    user.NombreUsu = reader[0].ToString();
                    user.Contraseña = reader[1].ToString();

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public DataTable ListarUsuarios()
        {
            DataTable listaUsuariosDT = new DataTable();

            try
            {
                string sql = "SELECT * FROM usuario;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaUsuariosDT.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return listaUsuariosDT;
        }

        public bool InsertarUsuario(Usuario usuario)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO usuario VALUES (@NombreUsu, @Contraseña);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("NombreUsu", usuario.NombreUsu);
                cmd.Parameters.AddWithValue("Contraseña", usuario.Contraseña);

                cmd.ExecuteNonQuery();
                inserto = true;

                conn.Close();
            }
            catch (Exception)
            {
            }
            return inserto;
        }
    }
}
