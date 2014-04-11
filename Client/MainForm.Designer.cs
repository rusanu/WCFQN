namespace Client
{
    partial class MainForm
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
            this.btnFetch = new System.Windows.Forms.Button();
            this.grdViewer = new System.Windows.Forms.DataGridView();
            this.txtCookie = new System.Windows.Forms.TextBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(385, 248);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 0;
            this.btnFetch.Text = "Subscribe";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // grdViewer
            // 
            this.grdViewer.AllowUserToAddRows = false;
            this.grdViewer.AllowUserToDeleteRows = false;
            this.grdViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewer.Location = new System.Drawing.Point(13, 13);
            this.grdViewer.Name = "grdViewer";
            this.grdViewer.ReadOnly = true;
            this.grdViewer.Size = new System.Drawing.Size(447, 154);
            this.grdViewer.TabIndex = 1;
            // 
            // txtCookie
            // 
            this.txtCookie.Location = new System.Drawing.Point(13, 250);
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.Size = new System.Drawing.Size(366, 20);
            this.txtCookie.TabIndex = 2;
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(13, 174);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(447, 70);
            this.txtSQL.TabIndex = 3;
            this.txtSQL.Text = "SELECT t.[id], t.[key], t.[value] FROM dbo.[test] t";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 283);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.txtCookie);
            this.Controls.Add(this.grdViewer);
            this.Controls.Add(this.btnFetch);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.DataGridView grdViewer;
        private System.Windows.Forms.TextBox txtCookie;
        private System.Windows.Forms.TextBox txtSQL;
    }
}

