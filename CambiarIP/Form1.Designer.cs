
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
            this.label2 = new System.Windows.Forms.Label();
            this.mask4 = new System.Windows.Forms.TextBox();
            this.mask3 = new System.Windows.Forms.TextBox();
            this.mask2 = new System.Windows.Forms.TextBox();
            this.mask1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gate4 = new System.Windows.Forms.TextBox();
            this.gate3 = new System.Windows.Forms.TextBox();
            this.gate2 = new System.Windows.Forms.TextBox();
            this.gate1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.salida = new System.Windows.Forms.ToolStripMenuItem();
            this.s253 = new System.Windows.Forms.ToolStripMenuItem();
            this.s252 = new System.Windows.Forms.ToolStripMenuItem();
            this.ping = new System.Windows.Forms.ToolStripMenuItem();
            this.dhcpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actializarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certificadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Activar = new System.Windows.Forms.Button();
            this.ip4 = new System.Windows.Forms.TextBox();
            this.ip3 = new System.Windows.Forms.TextBox();
            this.ip2 = new System.Windows.Forms.TextBox();
            this.ip1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "IP:";
            // 
            // mask4
            // 
            this.mask4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask4.Location = new System.Drawing.Point(231, 64);
            this.mask4.Name = "mask4";
            this.mask4.Size = new System.Drawing.Size(39, 26);
            this.mask4.TabIndex = 8;
            this.mask4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // mask3
            // 
            this.mask3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask3.Location = new System.Drawing.Point(182, 64);
            this.mask3.Name = "mask3";
            this.mask3.Size = new System.Drawing.Size(39, 26);
            this.mask3.TabIndex = 7;
            this.mask3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // mask2
            // 
            this.mask2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask2.Location = new System.Drawing.Point(133, 64);
            this.mask2.Name = "mask2";
            this.mask2.Size = new System.Drawing.Size(39, 26);
            this.mask2.TabIndex = 6;
            this.mask2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // mask1
            // 
            this.mask1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mask1.Location = new System.Drawing.Point(84, 64);
            this.mask1.Name = "mask1";
            this.mask1.Size = new System.Drawing.Size(39, 26);
            this.mask1.TabIndex = 5;
            this.mask1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 29);
            this.label5.TabIndex = 15;
            this.label5.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(169, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 29);
            this.label6.TabIndex = 17;
            this.label6.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(219, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 29);
            this.label7.TabIndex = 16;
            this.label7.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Mask:";
            // 
            // gate4
            // 
            this.gate4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gate4.Location = new System.Drawing.Point(231, 96);
            this.gate4.Name = "gate4";
            this.gate4.Size = new System.Drawing.Size(39, 26);
            this.gate4.TabIndex = 12;
            this.gate4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // gate3
            // 
            this.gate3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gate3.Location = new System.Drawing.Point(182, 96);
            this.gate3.Name = "gate3";
            this.gate3.Size = new System.Drawing.Size(39, 26);
            this.gate3.TabIndex = 11;
            this.gate3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // gate2
            // 
            this.gate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gate2.Location = new System.Drawing.Point(133, 96);
            this.gate2.Name = "gate2";
            this.gate2.Size = new System.Drawing.Size(39, 26);
            this.gate2.TabIndex = 10;
            this.gate2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // gate1
            // 
            this.gate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gate1.Location = new System.Drawing.Point(84, 96);
            this.gate1.Name = "gate1";
            this.gate1.Size = new System.Drawing.Size(39, 26);
            this.gate1.TabIndex = 9;
            this.gate1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.presionar_tecla);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(120, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 29);
            this.label9.TabIndex = 23;
            this.label9.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(169, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 29);
            this.label10.TabIndex = 25;
            this.label10.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(219, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 29);
            this.label11.TabIndex = 24;
            this.label11.Text = ".";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Puerta:";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salida,
            this.ping,
            this.dhcpToolStripMenuItem,
            this.actializarToolStripMenuItem,
            this.certificadoToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(300, 24);
            this.menu.TabIndex = 27;
            this.menu.Text = "menuStrip1";
            // 
            // salida
            // 
            this.salida.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s253,
            this.s252});
            this.salida.Name = "salida";
            this.salida.Size = new System.Drawing.Size(50, 20);
            this.salida.Text = "Salida";
            // 
            // s253
            // 
            this.s253.Name = "s253";
            this.s253.Size = new System.Drawing.Size(107, 22);
            this.s253.Text = "18.253";
            this.s253.Click += new System.EventHandler(this.s253_Click);
            // 
            // s252
            // 
            this.s252.Name = "s252";
            this.s252.Size = new System.Drawing.Size(107, 22);
            this.s252.Text = "16.252";
            this.s252.Click += new System.EventHandler(this.s252_Click);
            // 
            // ping
            // 
            this.ping.Name = "ping";
            this.ping.Size = new System.Drawing.Size(43, 20);
            this.ping.Text = "Ping";
            this.ping.Click += new System.EventHandler(this.ping_Click);
            // 
            // dhcpToolStripMenuItem
            // 
            this.dhcpToolStripMenuItem.Name = "dhcpToolStripMenuItem";
            this.dhcpToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dhcpToolStripMenuItem.Text = "DHCP";
            this.dhcpToolStripMenuItem.Click += new System.EventHandler(this.dhcpToolStripMenuItem_Click);
            // 
            // actializarToolStripMenuItem
            // 
            this.actializarToolStripMenuItem.Name = "actializarToolStripMenuItem";
            this.actializarToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.actializarToolStripMenuItem.Text = "Actualizar";
            this.actializarToolStripMenuItem.Click += new System.EventHandler(this.actializarToolStripMenuItem_Click);
            // 
            // certificadoToolStripMenuItem
            // 
            this.certificadoToolStripMenuItem.Name = "certificadoToolStripMenuItem";
            this.certificadoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.certificadoToolStripMenuItem.Text = "Certificado";
            this.certificadoToolStripMenuItem.Click += new System.EventHandler(this.certificadoToolStripMenuItem_Click);
            // 
            // Activar
            // 
            this.Activar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Activar.Location = new System.Drawing.Point(112, 129);
            this.Activar.Name = "Activar";
            this.Activar.Size = new System.Drawing.Size(92, 30);
            this.Activar.TabIndex = 13;
            this.Activar.Text = "Activar";
            this.Activar.UseVisualStyleBackColor = true;
            this.Activar.Click += new System.EventHandler(this.Activar_Click);
            // 
            // ip4
            // 
            this.ip4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip4.Location = new System.Drawing.Point(231, 30);
            this.ip4.Name = "ip4";
            this.ip4.Size = new System.Drawing.Size(39, 26);
            this.ip4.TabIndex = 4;
            // 
            // ip3
            // 
            this.ip3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip3.Location = new System.Drawing.Point(182, 30);
            this.ip3.Name = "ip3";
            this.ip3.Size = new System.Drawing.Size(39, 26);
            this.ip3.TabIndex = 3;
            // 
            // ip2
            // 
            this.ip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip2.Location = new System.Drawing.Point(133, 30);
            this.ip2.Name = "ip2";
            this.ip2.Size = new System.Drawing.Size(39, 26);
            this.ip2.TabIndex = 2;
            // 
            // ip1
            // 
            this.ip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip1.Location = new System.Drawing.Point(84, 30);
            this.ip1.Name = "ip1";
            this.ip1.Size = new System.Drawing.Size(39, 26);
            this.ip1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 29);
            this.label1.TabIndex = 32;
            this.label1.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(169, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 29);
            this.label3.TabIndex = 34;
            this.label3.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(219, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 29);
            this.label4.TabIndex = 33;
            this.label4.Text = ".";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 169);
            this.Controls.Add(this.ip4);
            this.Controls.Add(this.ip3);
            this.Controls.Add(this.ip2);
            this.Controls.Add(this.ip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Activar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.gate4);
            this.Controls.Add(this.gate3);
            this.Controls.Add(this.gate2);
            this.Controls.Add(this.gate1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mask4);
            this.Controls.Add(this.mask3);
            this.Controls.Add(this.mask2);
            this.Controls.Add(this.mask1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar IP - V1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mask4;
        private System.Windows.Forms.TextBox mask3;
        private System.Windows.Forms.TextBox mask2;
        private System.Windows.Forms.TextBox mask1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox gate4;
        private System.Windows.Forms.TextBox gate3;
        private System.Windows.Forms.TextBox gate2;
        private System.Windows.Forms.TextBox gate1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem salida;
        private System.Windows.Forms.ToolStripMenuItem s253;
        private System.Windows.Forms.ToolStripMenuItem s252;
        private System.Windows.Forms.ToolStripMenuItem ping;
        private System.Windows.Forms.Button Activar;
        private System.Windows.Forms.TextBox ip4;
        private System.Windows.Forms.TextBox ip3;
        private System.Windows.Forms.TextBox ip2;
        private System.Windows.Forms.TextBox ip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem dhcpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actializarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem certificadoToolStripMenuItem;
    }
}

