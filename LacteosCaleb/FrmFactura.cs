using LacteosCaleb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static LacteosCaleb.Conexion;
using System.Windows;
using System.Runtime.Remoting.Messaging;
using Microsoft.Identity.Client;

namespace LacteosCaleb
{
    public partial class FrmFactura : Form
       

    {
        private Conexion conex;
        private int ide; //variable que sirve como parametro para el valor de la ultima factura y que sea llamada en el reporte
        private BindingSource bindingSource1 = new BindingSource();
        public FrmFactura()
        {
            InitializeComponent();
            conex = new Conexion();

        }

       
       

        SqlConnection haja = new SqlConnection("Data Source=localhost\\SQLEXPRESS ;Initial Catalog=BD_LACTEOSCALEB; Integrated Security=true ");
        Conexion Conex = new Conexion(); //llamado para las funciones de la clase Conexion
        string query;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu FormularioNuevo = new FrmMenu();// llamado a formulario menú mediante un botón
            FormularioNuevo.MostrarUsuario(DatosUsuario.Usuario);// variable que hace el llamado del nombre del usuario en el formulario de usuario que sea llamado en el form de factura
            FormularioNuevo.Show();// la muestra
            this.Hide();//oculta el formulario actual

        }

        public void MostrarUsuario(string usuario) // funcion que usamos para llamar el usuario
        {
            txtUsuario.Text = usuario; //la variable que guarda lo que esta en el textbox que contiene el nombre del usuario en este formulario
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            autonum();// funcion del autonum
            //aca agreuge esto para añadir las opciones al combobox
            cmbreporteFopciones.Items.Add("Reporte Diario");
            cmbreporteFopciones.Items.Add("Resumen del dia");
            cmbreporteFopciones.Items.Add("Buscar Codigo de Factura");
            cmbreporteFopciones.Items.Add("Buscar Mes de Facturas");
            cmbreporteFopciones.Items.Add("Buscar factura de una fecha");

        }

        private void AÑADIR_Click(object sender, EventArgs e)
        {

            if (producttxt.Text == "" || preciotextbox.Text == "" || cantidadtxt.Text == "")//linea que dice que si dicho campo este en blanco haga las condiciones
            {
                MessageBox.Show("PARA AÑADIR DEBE TENER LOS CAMPOS DE PRODUCTO COMPLETOS");//permite que muestre este messagebox
            }
            else
            {
                bool productoExiste = false;

                // Recorre las filas del DataGridView para verificar si el producto ya está en la primera columna
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == IdProdTxt.Text)
                    {
                        productoExiste = true;
                        break;
                    }
                }

                if (productoExiste)
                {
                    MessageBox.Show("NO SE PUEDE AGREGAR EL MISMO PRODUCTO VARIAS VECES EN LA TABLA");
                    cantidadtxt.Clear();
                    producttxt.Clear(); 
                    preciotextbox.Clear();
                }
                else
                {
                    double linea = int.Parse(preciotextbox.Text) * int.Parse(cantidadtxt.Text);// esta variable loque hace es que multiplica el valor de la cantidad y el precio
                    dataGridView1.Rows.Add(IdProdTxt.Text, producttxt.Text, cantidadtxt.Text, preciotextbox.Text, linea);// aca se agrega en las filas lo que vayamos agregando en los textbox en el datagrid

                    //limpian los textbox estas lineas te codigo
                    IdProdTxt.Clear();
                    IdProdTxt.Focus();
                    producttxt.Clear();
                    cantidadtxt.Clear();
                    preciotextbox.Clear();

                    calcular();// llamado que hace que la funcion que hace que automaticamente se calcule el subtotal, impuesto y total
                }





            }
        }

        private void calcular() // funcion que hace que automaticamente se calcule el subtotal, impuesto y total
        {
            double total = 0;// variable inicializada en 0
            foreach (DataGridViewRow row in dataGridView1.Rows)// se mueve a través de cada fila en dataGridView1
            {
                if (row.Cells[4].Value != null)// verifica si el valor de la celda en la columna 4 de la fila no es nulo
                {
                    total += Convert.ToInt32(row.Cells[4].Value);// convierte el valor de la celda a entero y lo suma a total
                }
            }

            // valores del datagrid a textbox de calculo
            RPARCIAL.Text = total.ToString();//valor del subtotal
            RIVA.Text = (total * 0.15).ToString();// el impuesto de ello
            RPAGAR.Text = (total + Convert.ToDouble(RIVA.Text)).ToString();//sumatoria de impuesto y subtotal
        }
        
     
        

        private void label7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);// elimina mediante este boton la fila que seleccionemos
            calcular();// llamado que hace que la funcion que hace que automaticamente se calcule el subtotal, impuesto y total

            DateTime fec = dateTimePicker1.Value;
            string fechaSQL = fec.ToString("yyyy-MM-dd HH:mm:ss"); // formato compatible
            string acti = "Eliminó en FACTURA";
            string usariolabel = txtUsuario.Text;

            conex.Modificaciones($"exec IngresarBitacora '{fechaSQL}', '{usariolabel}', '{acti}'");

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
        }
        
        private void autonum()// funcion que hace que cada vez que paguemos incremente el número de la factura.
        {
            string servidor = "localhost\\SQLEXPRESS";//variable que guarda el nombre del servidor localhost  
          //  string servidor = "DESKTOP-09GMK57\\SQLEXPRESS";//variable que guarda el nombre de mi servidor en SQL SERVER 2019
            string strConn = "Data Source=" + servidor + "; Initial Catalog=BD_LACTEOSCALEB; Integrated Security=true";//linea que guarda los parametros para mi conexion a la base de datos
            SqlConnection conn = new SqlConnection(strConn);// crea una nueva instancia de SqlConnection usando la cadena de conexión
            string query = "SELECT MAX(IdFactEn) FROM FACTURAENCABEZADO";// linea de codigo que hace que en mi BD mediante una consulta busque el valor mas alto de el Id de la factura de la tabla de FACTURA ENCABEZADO
            SqlCommand cmd = new SqlCommand(query, conn);// crea una nueva instancia de SqlCommand utilizando la consulta y la conexión

            conn.Open();// abre la conexión a la base de datos
            object result = cmd.ExecuteScalar();// ejecuta la consulta y obtiene el primer valor de la primera fila del resultado
            conn.Close();//cierra la conexion
            int maxId;//variable que guardara el valor maximo del id de compra
            // Verifica si el resultado no es nulo antes de asignarlo al TextBox
            if (result != DBNull.Value)// si el resultado no es nulo
            {
                maxId = (Convert.ToInt32(result)+ 1);// convierte el resultado a entero y le suma 1, luego lo asigna a maxId
                txtfact.Text = maxId.ToString();// convierte maxId a cadena y lo asigna al TextBox txtCompra
            }
            else
            {
                // Maneja el caso en que no hay registros en la tabla
               maxId = 0;// asigna 0 a maxId si no hay registros
                txtfact.Text = maxId.ToString();// convierte maxId a cadena y lo asigna al TextBox txtCompra
            }
        }

     

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // verifica si el índice de la columna es 2 o 3
            {
                int fila = e.RowIndex;// obtiene el índice de la fila afectada por el evento
                decimal valor1 = Convert.ToDecimal(dataGridView1.Rows[fila].Cells[2].Value); // convierte el valor de la celda en la columna 2 de la fila afectada a decimal y lo asigna a valor1
                decimal valor2 = Convert.ToDecimal(dataGridView1.Rows[fila].Cells[3].Value); // convierte el valor de la celda en la columna 3 de la fila afectada a decimal y lo asigna a valor2
                decimal resultado = valor1 * valor2; // calcula el resultado multiplicando valor1 por valor2
                dataGridView1.Rows[fila].Cells[4].Value = resultado; // asigna el resultado a la celda en la columna 4 de la fila afectada


                decimal sumaParcial = 0;// declara una variable decimal para almacenar el subtotal
                foreach (DataGridViewRow row in dataGridView1.Rows)// se mueve a través de cada fila en dataGridView1
                {
                    if (row.Cells[4].Value != null) // verifica si el valor de la celda en la columna 4 de la fila no es nulo
                    {
                        sumaParcial += Convert.ToDecimal(row.Cells[4].Value);// convierte el valor de la celda a decimal y lo suma a sumaParcial
                    }
                }
                RPARCIAL.Text = sumaParcial.ToString(); //convierte a string y esta variable guarda el subtoal
              
                
                
               
            }
        }




        private void label9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("Debe agregar el DNI");
                return;
            }

            int ide = 0;

            DateTime fec = dateTimePicker1.Value; // Fecha de la factura
            string usua = txtUsuario.Text; // Usuario que registra
            string Dni = txtDNI.Text;
            bool est = checkBoxEstado.Checked;

            if (string.IsNullOrWhiteSpace(Dni))
            {
                MessageBox.Show("Debe agregar el DNI del cliente.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS; Initial Catalog=BD_LACTEOSCALEB; Integrated Security=true"))
                {
                    conn.Open();

                    using (SqlCommand cmdValida = new SqlCommand("ValidarDniCliente", conn))
                    {
                        cmdValida.CommandType = CommandType.StoredProcedure;
                        cmdValida.Parameters.AddWithValue("@DniConsulta", Dni);

                        // ExecuteScalar devuelve el valor de la columna 'Existe' (1 o 0)
                        int dniExiste = Convert.ToInt32(cmdValida.ExecuteScalar());


                            // ... (Tu validación de DNI)
                            if (dniExiste == 0)
                            {
                                MessageBox.Show($"El DNI {Dni} no está registrado como cliente. Debe registrar al cliente primero.", "Error de FK", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return; // Detiene la ejecución
                            }
                        
                    }


                    // Insertar factura encabezado
                    using (SqlCommand cmd = new SqlCommand("Facturadist", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fec", fec);
                        cmd.Parameters.AddWithValue("@usua", usua);
                        cmd.Parameters.AddWithValue("@Dni", Dni);
                        cmd.Parameters.AddWithValue("@est", est);

                        object result = cmd.ExecuteScalar(); // Lee el ID devuelto por el SP

                        if (result != null && result != DBNull.Value)
                        {
                            ide = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("La inserción del encabezado falló o no devolvió un ID.");
                        }
                    }


                    // Registrar bitácora de acción
                    using (SqlCommand cmd = new SqlCommand("IngresarBitacora", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fec", fec);
                        cmd.Parameters.AddWithValue("@usuariolabel", usua);
                        cmd.Parameters.AddWithValue("@Acti", "Pagó en FACTURA");
                        cmd.ExecuteNonQuery();
                    }

                    // Insertar detalles de factura y actualizar inventario
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            int idProd = Convert.ToInt32(row.Cells[0].Value);
                            int cantidad = Convert.ToInt32(row.Cells[2].Value);
                            decimal precio = Convert.ToDecimal(row.Cells[4].Value);

                            // Insertar detalle de factura
                            using (SqlCommand cmd = new SqlCommand("FacturaDet", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idd", ide);
                                cmd.Parameters.AddWithValue("@prod", idProd);
                                cmd.Parameters.AddWithValue("@cant", cantidad);
                                cmd.Parameters.AddWithValue("@preci", precio);
                                cmd.ExecuteNonQuery();
                            }

                            // Actualizar existencia del producto
                            using (SqlCommand cmd = new SqlCommand("RestarExistenciaProducto", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@IdProd", idProd);
                                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                                cmd.ExecuteNonQuery();
                            }
                        }

                    }


                    conn.Close();
                }

                // Limpiar interfaz
                txtDNI.Clear();
                RPARCIAL.Text = "";
                RIVA.Text = "";
                RPAGAR.Text = "";
                dataGridView1.Rows.Clear();

                MessageBox.Show("Factura registrada con éxito");

                // Mostrar reporte
                ReporteFactura1 repor = new ReporteFactura1(ide);
                repor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la factura: " + ex.Message);
            }
        }


          
       
        private void button3_Click(object sender, EventArgs e)//boton para ver PRODUCTOS
        {

            Conex.Grids("select IdPro as Codigo, NomPro as Producto,PrePro as Precio from PRODUCTOS", dataGridView2);//linea que muestra las columnas de la tabla PRODUCTOS
            dataGridView2.Columns[0].Width = 60;// establece el ancho de la primera columna de dataGridView2 a 60
            dataGridView2.Columns[2].Width = 70;// establece el ancho de la tercera columna de dataGridView2 a 70
            dataGridView2.Visible = true;//se hace visible el datagrid
            
        }
       
        private void DataGridView2_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            IdProdTxt.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();//linea de codigo que hace que cuando de doble click a una posicion de la columna se guarde en el textbox
            producttxt.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();//linea de codigo que hace que cuando de doble click a una posicion de la columna se guarde en el textbox
            preciotextbox.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();//linea de codigo que hace que cuando de doble click a una posicion de la columna se guarde en el textbox
            dataGridView2.Visible = false;//el datagrid no es visible
            
        }

        private void txtfact_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//boton para ver CLIENTE
        {
            Conex.Grids("select DNI  as DNI, NomCli as Nombre , TelCli as Telefono from CLIENTE", dataGridView3);//linea que muestra las columnas de la tabla CLIENTE
            dataGridView3.Columns[0].Width = 60;// Establece el ancho de la primera columna de dataGridView3 en 60.
            dataGridView3.Columns[2].Width = 70;// Establece el ancho de la tercera columna de dataGridView3 en 70.

            if (dataGridView3.Visible)// Verifica si dataGridView3 está visible.
            {

                dataGridView3.Hide();// Si dataGridView3 está visible, lo oculta.
            }
            else
            {
                // Si dataGridView3 no está visible, lo muestra y establece la propiedad Visible de dataGridView2 en false para ocultarlo.
                dataGridView3.Show();
                dataGridView2.Visible = false;

            }

        }
        

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDNI.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();//linea de codigo que hace que cuando de doble click a una posicion de la columna se guarde en el textbox
            dataGridView3.Visible = false;//el datagrid no es visible
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void CalcularDevolucion()//funcion que calcula devolucion
        {
            if (decimal.TryParse(txtefectivo.Text, out decimal efectivo) && decimal.TryParse(RPAGAR.Text, out decimal parcial))//guarda la informacion del textbox de efectivo y la del total en esas dos variables
            {
                decimal devolucion = efectivo - parcial;//resta lo que tienen estas variables y se guarda en devolucion
                txtdevolucion.Text = devolucion.ToString();//muestra el resulado de las restas
            }
            else
            {
                // Manejar el caso en el que el usuario ingresa valores no válidos
                txtdevolucion.Text = "";
            }
        }
           

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CalcularDevolucion();//funcion que calcula la devolucion
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            CalcularDevolucion();//funcion que calcula la devolucion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click_1(object sender, EventArgs e)
        {
            ReporteconCodigo reporcod = new ReporteconCodigo(ide);// llama al formulario como parametro el id factura
            reporcod.ShowDialog();//lo muestra

        }

        int mes = 1;//incicializamos la variable mes en 1
        DateTime fec = new DateTime(2024,1,1);//incicializamos la fecha
        

        private void cmbreporteFopciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbreporteFopciones.Text)//switch perteneciente a un combobox que guarda opciones de los reportes
            {
                case "Reporte Diario"://reporte diario
                    ReporteDiarioFacturaDetallada diarioreporte= new ReporteDiarioFacturaDetallada();//llama al formulario del reporte diario
                    diarioreporte.ShowDialog();//lo muestra
                    break;//cierra

                case "Resumen del dia":

                    ReporteResumenDiarioFactura resumen = new ReporteResumenDiarioFactura();//llama al formulario que muestra el resumen de ventas
                    resumen.ShowDialog();//lo muestra
                    break;//cierra

                case 
                    "Buscar Codigo de Factura":
                    
                    ReporteconCodigo reporcod = new ReporteconCodigo(ide);//llama al formulario con una variable que tiene guardado el id de factura
                    reporcod.ShowDialog();//lo muestra
                    break;//cierra

                case
                    "Buscar Mes de Facturas":

                    ReporteMesFechaFactura repor = new ReporteMesFechaFactura(mes);//llama al formulario con una variable que guarda el numero de mes como parametro
                    repor.ShowDialog();//lo muestra
                    break;//cierra

                case
                    "Buscar factura de una fecha":


                    ReporteElegirFechaFactura reporfec = new ReporteElegirFechaFactura(fec);////llama al formulario con una variable que guarda la fecha mes como parametro
                    reporfec.ShowDialog();//lo muestra

                    break;//cierra
                default:
                    
                    break;//cierra el combobox
            }
        }
    }
    
    }
