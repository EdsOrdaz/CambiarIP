
namespace CambiarIP
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.libre = new System.Windows.Forms.Button();
            this.telmex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // libre
            // 
            this.libre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libre.Location = new System.Drawing.Point(12, 12);
            this.libre.Name = "libre";
            this.libre.Size = new System.Drawing.Size(79, 57);
            this.libre.TabIndex = 0;
            this.libre.Text = "16.252";
            this.libre.UseVisualStyleBackColor = true;
            this.libre.Click += new System.EventHandler(this.libre_Click);
            // 
            // telmex
            // 
            this.telmex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telmex.Location = new System.Drawing.Point(107, 12);
            this.telmex.Name = "telmex";
            this.telmex.Size = new System.Drawing.Size(79, 57);
            this.telmex.TabIndex = 1;
            this.telmex.Text = "18.253";
            this.telmex.UseVisualStyleBackColor = true;
            this.telmex.Click += new System.EventHandler(this.telmex_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 82);
            this.Controls.Add(this.telmex);
            this.Controls.Add(this.libre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar IP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button libre;
        private System.Windows.Forms.Button telmex;
    }
}

