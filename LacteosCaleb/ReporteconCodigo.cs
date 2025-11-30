using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LacteosCaleb
{
    public partial class ReporteconCodigo : Form
    {
        private int ide;//variable que guarda el id factura
        public ReporteconCodigo(int ide)
        {
            InitializeComponent();
            this.ide = ide;// Asigna el valor de ide al campo de la clase
        }

        private void ReporteconCodigo_Load(object sender, EventArgs e)
        {

            this.BD_LACTEOSCALEBDataSetReporteFactura.EnforceConstraints = false;
            this.ReporteCodigoFacturaTableAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteFactura.ReporteFactura, ide);// Llena la tabla reportefactura con datos filtrados por ide
            this.reportViewer1.RefreshReport();// Actualiza el reportviewer para mostrar el nuevo informe
        }

        public void AsignarNuevoValor(int DNInuevo)//funcion que guarda  la variable del id factura
        {
            this.ide = DNInuevo;//se guarda
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(txtDNI.Text, out int nuevoValor))// Intenta convertir el texto de txtDNI a un entero y lo guarda en nuevoValor
            {

                AsignarNuevoValor(nuevoValor);// Llama a la función AsignarNuevoValor con el nuevoValor como argumento
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDNI.Text))
                {
                    ide = Convert.ToInt32(txtDNI.Text);
                }

                this.BD_LACTEOSCALEBDataSetReporteFactura.EnforceConstraints = false;

                // 1. Llenar la tabla correcta
                this.ReporteCodigoFacturaTableAdapter.Fill(
                    this.BD_LACTEOSCALEBDataSetReporteFactura.ReporteFactura, ide);

                // 2. Conectar con el ReportViewer
                this.reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource(
                "DataSet1",
                this.BD_LACTEOSCALEBDataSetReporteFactura.Tables["ReporteFactura"]);

                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}