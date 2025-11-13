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
    public partial class ReporteCompra : Form
    {
        private int ide;//variable que guarda el idcompra
        public ReporteCompra(int ide)// Constructor de la clase ReporteCompra que recibe un parámetro ide

        {
            this.ide = ide;// Asigna el valor del parámetro ide al campo ide de la clase
            InitializeComponent();
        }

        private void ReporteCompra_Load(object sender, EventArgs e)
        {
            // Limpia cualquier origen de datos anterior
            this.reportViewer1.LocalReport.DataSources.Clear();

            // --- 1. PREPARAR TABLA DE ENCABEZADO ---

            // Crear la instancia del TableAdapter para el Encabezado
            
            BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_EncabezadoTableAdapter encabezadoAdapter =
                new BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_EncabezadoTableAdapter();

            // Crear la instancia de la DataTable para el Encabezado
            BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_EncabezadoDataTable encabezadoTabla =
                new BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_EncabezadoDataTable();

            // Llenar la tabla de encabezado con el 'ide'
            encabezadoAdapter.Fill(encabezadoTabla, ide);

            // Crear el origen de datos (ReportDataSource) para el Encabezado
            
            Microsoft.Reporting.WinForms.ReportDataSource rdsEncabezado =
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSetEncabezado", (System.Data.DataTable)encabezadoTabla);


            // --- 2. PREPARAR TABLA DE DETALLE ---

            // Crear la instancia del TableAdapter para el Detalle
            BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_DetalleTableAdapter detalleAdapter =
                new BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_DetalleTableAdapter();

            // Crear la instancia de la DataTable para el Detalle
            BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_DetalleDataTable detalleTabla =
                new BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompra_DetalleDataTable();

            // Llenar la tabla de detalle con el 'ide'
            detalleAdapter.Fill(detalleTabla, ide);

            // Crear el origen de datos (ReportDataSource) para el Detalle
            
            Microsoft.Reporting.WinForms.ReportDataSource rdsDetalle =
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSetDetalle", (System.Data.DataTable)detalleTabla);


            // --- 3. ASIGNAR AL REPORTE Y ACTUALIZAR ---

            // Agregar AMBOS orígenes de datos al visor de reportes
            this.reportViewer1.LocalReport.DataSources.Add(rdsEncabezado);
            this.reportViewer1.LocalReport.DataSources.Add(rdsDetalle);

            // Refrescar el visor de reportes
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
