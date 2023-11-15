namespace LaEquina.Windows
{
    partial class FrmMiembrosAE
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
            this.cboEquipos = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.Apellido = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregarEquipos = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEquipos
            // 
            this.cboEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipos.FormattingEnabled = true;
            this.cboEquipos.Location = new System.Drawing.Point(131, 51);
            this.cboEquipos.Name = "cboEquipos";
            this.cboEquipos.Size = new System.Drawing.Size(300, 21);
            this.cboEquipos.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(131, 121);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Equipos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(131, 181);
            this.txtApellido.MaxLength = 100;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(300, 20);
            this.txtApellido.TabIndex = 16;
            // 
            // Apellido
            // 
            this.Apellido.AutoSize = true;
            this.Apellido.Location = new System.Drawing.Point(52, 188);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(44, 13);
            this.Apellido.TabIndex = 15;
            this.Apellido.Text = "Apellido";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::LaEquina.Windows.Properties.Resources.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(356, 259);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 73);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregarEquipos
            // 
            this.btnAgregarEquipos.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.btnAgregarEquipos.Location = new System.Drawing.Point(454, 42);
            this.btnAgregarEquipos.Name = "btnAgregarEquipos";
            this.btnAgregarEquipos.Size = new System.Drawing.Size(63, 56);
            this.btnAgregarEquipos.TabIndex = 12;
            this.btnAgregarEquipos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarEquipos.UseVisualStyleBackColor = true;
            this.btnAgregarEquipos.Click += new System.EventHandler(this.btnAgregarEquipos_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::LaEquina.Windows.Properties.Resources.Ok;
            this.btnOk.Location = new System.Drawing.Point(66, 259);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(104, 73);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmMiembrosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 380);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.Apellido);
            this.Controls.Add(this.cboEquipos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarEquipos);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMiembrosAE";
            this.Text = "FrmMiembrosAE";
            this.Load += new System.EventHandler(this.FrmMiembrosAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEquipos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregarEquipos;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label Apellido;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}