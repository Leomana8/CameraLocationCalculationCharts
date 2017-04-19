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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            this.tableLayoutPanel1.Controls.Add(this.plotViewF, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.plotViewN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.90859F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.09141F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // plotViewF
            // 
            this.plotViewF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewF.Location = new System.Drawing.Point(3, 3);
            this.plotViewF.Name = "plotViewF";
            this.plotViewF.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewF.Size = new System.Drawing.Size(393, 307);
            this.plotViewF.TabIndex = 0;
            this.plotViewF.Text = "plotView1";
            this.plotViewF.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewF.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewF.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotViewN
            // 
            this.plotViewN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotViewN.Location = new System.Drawing.Point(3, 316);
            this.plotViewN.Name = "plotViewN";
            this.plotViewN.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewN.Size = new System.Drawing.Size(393, 310);
            this.plotViewN.TabIndex = 1;
            this.plotViewN.Text = "plotView1";
            this.plotViewN.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewN.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewN.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(402, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(297, 307);
            this.propertyGrid1.TabIndex = 2;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.UseWaitCursor = true;
            // 
            // Charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Charts";
            this.Text = "Графики";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OxyPlot.WindowsForms.PlotView plotViewF;
        private OxyPlot.WindowsForms.PlotView plotViewN;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}