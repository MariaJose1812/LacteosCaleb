using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LacteosCaleb
{
    public partial class ReportePorCodigoCompras : Form
    {
        private int ide;// campo privado para almacenar el ID
        public ReportePorCodigoCompras(int ide )
        {
            InitializeComponent();// inicializa los componentes del formulario
            this.ide = ide;// asigna el valor del ID pasado al campo 'ide'
        }
        public void AsignarNuevoValor(int DNInuevo)//funcion publica que contiene el DNI
        {
            this.ide = DNInuevo;// asigna un nuevo valor al campo 'ide'
        }
        private void ReportePorCodigoCompras_Load(object sender, EventArgs e)
        {
            // Establecer el reporte RDLC
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LacteosCaleb.ReportCompra.rdlc";

            // Llenar el adaptador de tabla con los datos filtrados por 'ide'
            this.reporteCompraTableAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_Encabezado, ide);

            this.reportViewer1.RefreshReport();
        }


        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            // intenta convertir el texto ingresado en el campo de texto a un entero
            if (int.TryParse(txtDNI.Text, out int nuevoValor))
            {

                AsignarNuevoValor(nuevoValor);// asigna el nuevo valor convertido al campo 'ide'
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDNI.Text, out int nuevoValor))
            {
                AsignarNuevoValor(nuevoValor);
                CargarReporte();
            }
            else
            {
                MessageBox.Show("Ingrese un código válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarReporte()
        {
            try
            {
                // 1. Limpiar dataset
                this.BD_LACTEOSCALEBDataSetReporteCompra.Clear();

                // 2. Llenar encabezado
                this.reporteCompra_EncabezadoTableAdapter1.Fill(
                    this.BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_Encabezado,
                    ide
                );

                // 3. Llenar detalle
                this.reporteCompra_DetalleTableAdapter1.Fill(
                    this.BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_Detalle,
                    ide
                );

                // Validar si hay resultados
                if (this.BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_Encabezado.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró una compra con ese código.",
                                    "Sin resultados",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                // 4. Limpiar las fuentes del ReportViewer
                this.reportViewer1.LocalReport.DataSources.Clear();

                // 5. Agregar DataSource para ENCABEZADO
                Microsoft.Reporting.WinForms.ReportDataSource rdsEncabezado = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetEncabezado", this.BD_LACTEOSCALEBDataSetReporteCompra.Tables["ReporteCompra_Encabezado"]);

                // 6. Agregar DataSource para DETALLE
                Microsoft.Reporting.WinForms.ReportDataSource rdsDetalle = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetDetalle", this.BD_LACTEOSCALEBDataSetReporteCompra.Tables["ReporteCompra_Detalle"]);

                this.reportViewer1.LocalReport.DataSources.Add(rdsEncabezado);
                this.reportViewer1.LocalReport.DataSources.Add(rdsDetalle);

                // 7. Actualizar reporte
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
