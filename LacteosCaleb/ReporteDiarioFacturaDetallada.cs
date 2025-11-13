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
    public partial class ReporteDiarioFacturaDetallada : Form
    {
        public ReporteDiarioFacturaDetallada()
        {
            InitializeComponent();
        }

        private void ReporteDiarioFacturaDetallada_Load(object sender, EventArgs e)
        {
            // Se debe proporcionar un valor para el parámetro requerido "Fecha".
            // Aquí se usa la fecha actual como ejemplo. Cambie según su lógica de negocio.
            DateTime fecha = DateTime.Today;

            // El método Fill no acepta un parámetro de fecha directamente.
            // Simplemente llama a Fill para llenar la tabla completa.
            this.reporteFacturaDiariaTableAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteFactura.ReporteFacturaDiaria, fecha);

            this.reportViewer1.RefreshReport();//actualiza la informacion del reporrtviewer
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
