namespace CameraLocationCalculationCharts
{
    partial class Charts
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.plotViewF = new OxyPlot.WindowsForms.PlotView();
            this.plotViewN = new OxyPlot.WindowsForms.PlotView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.plotViewF, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.plotViewN, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // plotViewF
            // 
            this.plotViewF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewF.Location = new System.Drawing.Point(3, 31);
            this.plotViewF.Name = "plotViewF";
            this.plotViewF.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewF.Size = new System.Drawing.Size(304, 328);
            this.plotViewF.TabIndex = 0;
            this.plotViewF.Text = "plotView1";
            this.plotViewF.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewF.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewF.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotViewN
            // 
            this.plotViewN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewN.Location = new System.Drawing.Point(313, 31);
            this.plotViewN.Name = "plotViewN";
            this.plotViewN.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewN.Size = new System.Drawing.Size(305, 328);
            this.plotViewN.TabIndex = 1;
            this.plotViewN.Text = "plotView2";
            this.plotViewN.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewN.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewN.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Charts";
            this.Text = "Charts";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OxyPlot.WindowsForms.PlotView plotViewF;
        private OxyPlot.WindowsForms.PlotView plotViewN;
    }
}