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
    public partial class ReporteFactura1 : Form
    {
        private int ide;//variable que guarda el id de factura
        public ReporteFactura1(int ide)
        {
            InitializeComponent();
            this.ide = ide;// Asigna el valor de ide al campo de la clase this.ide
        }

        private void ReporteFactura1_Load(object sender, EventArgs e)
        {
            try
            {
                // Opcional: desactivar restricciones mientras llenas
                this.BD_LACTEOSCALEBDataSetReporteFactura.EnforceConstraints = false;

                // Llenar encabezado
                var encabezadoAdapter = new BD_LACTEOSCALEBDataSetReporteFacturaTableAdapters.ReporteFacturaEncabezadoTableAdapter();
                encabezadoAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteFactura.ReporteFacturaEncabezado, ide);

                // Llenar detalle
                var detalleAdapter = new BD_LACTEOSCALEBDataSetReporteFacturaTableAdapters.ReporteFacturaDetalleTableAdapter();
                detalleAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteFactura.ReporteFacturaDetalle, ide);

                // Si usas ReportViewer: refrescar el informe
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DataSetEncabezado",
                        (object)this.BD_LACTEOSCALEBDataSetReporteFactura.ReporteFacturaEncabezado));
                this.reportViewer1.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DataSetDetalle",
                        (object)this.BD_LACTEOSCALEBDataSetReporteFactura.ReporteFacturaDetalle));
                this.reportViewer1.RefreshReport();

                // Reactivar restricciones
                this.BD_LACTEOSCALEBDataSetReporteFactura.EnforceConstraints = true;
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("Error de restricciones: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }


        private void ReporteFacturaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
