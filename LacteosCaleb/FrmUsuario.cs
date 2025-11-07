using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static LacteosCaleb.Conexion;

namespace LacteosCaleb
{
    public partial class FrmUsuario : Form
    {
        private Conexion conex; 

        public FrmUsuario()
        {
            InitializeComponent();
            conex = new Conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsur.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña.");
                return;
            }

            try
            {
                // Comando SQL parametrizado para login
                string sqlLogin = "SELECT NomUsu FROM USUARIOS WHERE NomUsu = @usuario AND ConUsu = @contrasena";

                using (SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BD_LACTEOSCALEB;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(sqlLogin, conn))
                {
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = txtUsur.Text;
                    cmd.Parameters.Add("@contrasena", SqlDbType.VarChar, 50).Value = txtContrasena.Text;

                    conn.Open();
                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            // Login exitoso
                            DatosUsuario.Usuario = txtUsur.Text;

                            FrmMenu pantalla = new FrmMenu();
                            FrmFactura verusuario = new FrmFactura();

                            pantalla.usrlabel.Text = txtUsur.Text;
                            verusuario.txtUsuario.Text = txtUsur.Text;

                            MessageBox.Show($"¡Bienvenido al sistema, {txtUsur.Text}!");

                            pantalla.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña inválido, intente nuevamente.");
                        }
                    }
                }

                // Guardar bitácora usando la clase Conexion
                DateTime fecha = dateTimePicker1.Value;
                string accion = "Ingresó al Sistema";
                string usuario = txtUsur.Text;

                string procedimientoBitacora = "exec IngresarBitacora @fecha, @usuario, @accion";

                using (SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BD_LACTEOSCALEB;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(procedimientoBitacora, conn))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                    cmd.Parameters.Add("@accion", SqlDbType.VarChar, 100).Value = accion;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicialización si es necesaria
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Manejo de cambios en el DateTimePicker si es necesario
        }
    }
}
