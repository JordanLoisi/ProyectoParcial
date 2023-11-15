namespace LaEquina.Windows
{
    partial class FrmPartidosAE
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
            this.cboRondas = new System.Windows.Forms.ComboBox();
            this.btnAgregarTorneo = new System.Windows.Forms.Button();
            this.cboEquipoB = new System.Windows.Forms.ComboBox();
            this.btnArgregarEquipoB = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTorneo = new System.Windows.Forms.ComboBox();
            this.BtnAgregarRondas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEquipo = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregarEquipoA = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboRondas
            // 
            this.cboRondas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRondas.FormattingEnabled = true;
            this.cboRondas.Location = new System.Drawing.Point(115, 153);
            this.cboRondas.Name = "cboRondas";
            this.cboRondas.Size = new System.Drawing.Size(300, 21);
            this.cboRondas.TabIndex = 47;
            // 
            // btnAgregarTorneo
            // 
            this.btnAgregarTorneo.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.btnAgregarTorneo.Location = new System.Drawing.Point(458, 196);
            this.btnAgregarTorneo.Name = "btnAgregarTorneo";
            this.btnAgregarTorneo.Size = new System.Drawing.Size(61, 55);
            this.btnAgregarTorneo.TabIndex = 46;
            this.btnAgregarTorneo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarTorneo.UseVisualStyleBackColor = true;
            this.btnAgregarTorneo.Click += new System.EventHandler(this.btnAgregarTorneo_Click);
            // 
            // cboEquipoB
            // 
            this.cboEquipoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipoB.FormattingEnabled = true;
            this.cboEquipoB.Location = new System.Drawing.Point(115, 94);
            this.cboEquipoB.Name = "cboEquipoB";
            this.cboEquipoB.Size = new System.Drawing.Size(300, 21);
            this.cboEquipoB.TabIndex = 45;
            // 
            // btnArgregarEquipoB
            // 
            this.btnArgregarEquipoB.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.btnArgregarEquipoB.Location = new System.Drawing.Point(458, 78);
            this.btnArgregarEquipoB.Name = "btnArgregarEquipoB";
            this.btnArgregarEquipoB.Size = new System.Drawing.Size(61, 53);
            this.btnArgregarEquipoB.TabIndex = 44;
            this.btnArgregarEquipoB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnArgregarEquipoB.UseVisualStyleBackColor = true;
            this.btnArgregarEquipoB.Click += new System.EventHandler(this.btnArgregarEquipoB_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "EquipoB";
            // 
            // cboTorneo
            // 
            this.cboTorneo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTorneo.FormattingEnabled = true;
            this.cboTorneo.Location = new System.Drawing.Point(115, 214);
            this.cboTorneo.Name = "cboTorneo";
            this.cboTorneo.Size = new System.Drawing.Size(300, 21);
            this.cboTorneo.TabIndex = 42;
            // 
            // BtnAgregarRondas
            // 
            this.BtnAgregarRondas.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.BtnAgregarRondas.Location = new System.Drawing.Point(465, 137);
            this.BtnAgregarRondas.Name = "BtnAgregarRondas";
            this.BtnAgregarRondas.Size = new System.Drawing.Size(54, 53);
            this.BtnAgregarRondas.TabIndex = 41;
            this.BtnAgregarRondas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAgregarRondas.UseVisualStyleBackColor = true;
            this.BtnAgregarRondas.Click += new System.EventHandler(this.BtnAgregarRondas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Torneo";
            // 
            // cboEquipo
            // 
            this.cboEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipo.FormattingEnabled = true;
            this.cboEquipo.Location = new System.Drawing.Point(115, 34);
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(300, 21);
            this.cboEquipo.TabIndex = 39;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::LaEquina.Windows.Properties.Resources.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(330, 306);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 68);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregarEquipoA
            // 
            this.btnAgregarEquipoA.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.btnAgregarEquipoA.Location = new System.Drawing.Point(458, 12);
            this.btnAgregarEquipoA.Name = "btnAgregarEquipoA";
            this.btnAgregarEquipoA.Size = new System.Drawing.Size(50, 60);
            this.btnAgregarEquipoA.TabIndex = 37;
            this.btnAgregarEquipoA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarEquipoA.UseVisualStyleBackColor = true;
            this.btnAgregarEquipoA.Click += new System.EventHandler(this.btnAgregarEquipoA_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::LaEquina.Windows.Properties.Resources.Ok;
            this.btnOk.Location = new System.Drawing.Point(80, 306);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(107, 68);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "EquipoA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Rondas";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(140, 270);
            this.txtResultado.MaxLength = 100;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(300, 20);
            this.txtResultado.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Resultado";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmPartidosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 386);
            this.ControlBox = false;
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboRondas);
            this.Controls.Add(this.btnAgregarTorneo);
            this.Controls.Add(this.cboEquipoB);
            this.Controls.Add(this.btnArgregarEquipoB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTorneo);
            this.Controls.Add(this.BtnAgregarRondas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboEquipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarEquipoA);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPartidosAE";
            this.Text = "FrmPartidosAE";
            this.Load += new System.EventHandler(this.FrmPartidosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRondas;
        private System.Windows.Forms.Button btnAgregarTorneo;
        private System.Windows.Forms.ComboBox cboEquipoB;
        private System.Windows.Forms.Button btnArgregarEquipoB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTorneo;
        private System.Windows.Forms.Button BtnAgregarRondas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEquipo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregarEquipoA;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}