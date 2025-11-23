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
    public partial class ReporteElegirFechaFactura : Form
    {
        private DateTime fec;//variable tipo datettime
        public ReporteElegirFechaFactura(DateTime fec)
        {
            InitializeComponent();
            this.fec = fec;// Asigna el valor de fec al campo de la clase this.fec
        }

        // Reemplaza todas las referencias a "ReportepordiaFactura" por "ReportepordiasFactura" en el archivo

        private void ReporteElegirFechaFactura_Load(object sender, EventArgs e)
        {
            this.reportepordiasFacturaTableAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteFactura.ReportepordiasFactura, fec);// Llena la tabla reportepordiasFactura con datos filtrados por fec
            this.reportViewer1.RefreshReport();// Actualiza el reportviewer para mostrar el nuevo informe
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dateTimePicker1.Text, out DateTime nuevaFecha))// Intenta convertir el texto del dateTimePicker a DateTime y lo guarda en nuevaFecha
            {
                AsignarNuevaFecha(nuevaFecha);// Llama a la función AsignarNuevaFecha con nuevaFecha como argument
            }
        }
        public void AsignarNuevaFecha(DateTime nuevaFecha)
        {
            this.fec = nuevaFecha;// Asigna el valor de nuevaFecha al campo de la clase fec
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportepordiasFacturaTableAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteFactura.ReportepordiasFactura, fec);// Llena la tabla reportepordiasFactura con datos filtrados por fec
            this.reportViewer1.RefreshReport();// Actualiza el reportviewer para mostrar el nuevo informe
        }
    }
}
