namespace LacteosCaleb
{
    partial class ReporteconCodigo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteconCodigo));
            this.reporteFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BD_LACTEOSCALEBDataSetReporteFactura = new LacteosCaleb.BD_LACTEOSCALEBDataSetReporteFactura();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReporteCodigoFacturaTableAdapter = new LacteosCaleb.BD_LACTEOSCALEBDataSetReporteFacturaTableAdapters.ReporteFacturaTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.reporteCompra_DetalleTableAdapter1 = new LacteosCaleb.BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_DetalleTableAdapter();
            this.reporteCompra_EncabezadoTableAdapter1 = new LacteosCaleb.BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_EncabezadoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BD_LACTEOSCALEBDataSetReporteFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteFacturaBindingSource
            // 
            this.reporteFacturaBindingSource.DataMember = "ReporteFactura";
            this.reporteFacturaBindingSource.DataSource = this.BD_LACTEOSCALEBDataSetReporteFactura;
            // 
            // BD_LACTEOSCALEBDataSetReporteFactura
            // 
            this.BD_LACTEOSCALEBDataSetReporteFactura.DataSetName = "BD_LACTEOSCALEBDataSetReporteFactura";
            this.BD_LACTEOSCALEBDataSetReporteFactura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(175, 161);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(283, 22);
            this.txtDNI.TabIndex = 20;
            this.txtDNI.TextChanged += new System.EventHandler(this.txtDNI_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(16, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Código:";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteFacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LacteosCaleb.ReporteCodigoFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 214);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(845, 440);
            this.reportViewer1.TabIndex = 23;
            // 
            // ReporteCodigoFacturaTableAdapter
            // 
            this.ReporteCodigoFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 156);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 24;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(301, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Reporte por busqueda de código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(356, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 31);
            this.label3.TabIndex = 39;
            this.label3.Text = "FACTURA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(360, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Danlí, El Paraíso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(332, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 29);
            this.label1.TabIndex = 37;
            this.label1.Text = "LÁCTEOS CALEB";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(685, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(100, 10);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(89, 89);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // reporteCompra_DetalleTableAdapter1
            // 
            this.reporteCompra_DetalleTableAdapter1.ClearBeforeFill = true;
            // 
            // reporteCompra_EncabezadoTableAdapter1
            // 
            this.reporteCompra_EncabezadoTableAdapter1.ClearBeforeFill = true;
            // 
            // ReporteconCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(872, 666);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReporteconCodigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportePorCodigo";
            this.Load += new System.EventHandler(this.ReporteconCodigo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BD_LACTEOSCALEBDataSetReporteFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label6;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteFacturaBindingSource;
        private BD_LACTEOSCALEBDataSetReporteFactura BD_LACTEOSCALEBDataSetReporteFactura;
        private BD_LACTEOSCALEBDataSetReporteFacturaTableAdapters.ReporteFacturaTableAdapter ReporteCodigoFacturaTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_DetalleTableAdapter reporteCompra_DetalleTableAdapter1;
        private BD_LACTEOSCALEBDataSetReporteCompraTableAdapters.ReporteCompra_EncabezadoTableAdapter reporteCompra_EncabezadoTableAdapter1;
    }
}