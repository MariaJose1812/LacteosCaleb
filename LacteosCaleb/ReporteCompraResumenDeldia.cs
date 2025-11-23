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
    public partial class ReporteCompraResumenDeldia : Form
    {
        public ReporteCompraResumenDeldia()
        {
            InitializeComponent();
        }

        private void ReporteCompraResumenDeldia_Load(object sender, EventArgs e)
        {
            this.reporteCompraResumenDelDiaTableAdapter.Fill(this.BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompraResumenDelDia);

            this.reportViewer1.LocalReport.DataSources.Clear();

            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource(
                "DataSetResumenDiarioCompra",
                (System.Data.DataTable)this.BD_LACTEOSCALEBDataSetReporteCompra.ReporteCompraResumenDelDia
            );

            
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
