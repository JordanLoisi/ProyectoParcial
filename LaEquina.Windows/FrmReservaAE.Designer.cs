namespace LaEquina.Windows
{
    partial class FrmReservaAE
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
            this.cboTurno = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregarHorario = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFecha = new System.Windows.Forms.ComboBox();
            this.BtnAgregarMiembro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbocanchas = new System.Windows.Forms.ComboBox();
            this.btnArgregarCanchas = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregarFecha = new System.Windows.Forms.Button();
            this.cboMiembro = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTurno
            // 
            this.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurno.FormattingEnabled = true;
            this.cboTurno.Location = new System.Drawing.Point(90, 30);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Size = new System.Drawing.Size(300, 21);
            this.cboTurno.TabIndex = 23;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::LaEquina.Windows.Properties.Resources.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(301, 273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 78);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregarHorario
            // 
            this.btnAgregarHorario.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.btnAgregarHorario.Location = new System.Drawing.Point(396, 15);
            this.btnAgregarHorario.Name = "btnAgregarHorario";
            this.btnAgregarHorario.Size = new System.Drawing.Size(63, 57);
            this.btnAgregarHorario.TabIndex = 21;
            this.btnAgregarHorario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarHorario.UseVisualStyleBackColor = true;
            this.btnAgregarHorario.Click += new System.EventHandler(this.btnAgregarHorario_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::LaEquina.Windows.Properties.Resources.Ok;
            this.btnOk.Location = new System.Drawing.Point(76, 273);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 78);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Horario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Miembro";
            // 
            // cboFecha
            // 
            this.cboFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFecha.FormattingEnabled = true;
            this.cboFecha.Location = new System.Drawing.Point(104, 215);
            this.cboFecha.Name = "cboFecha";
            this.cboFecha.Size = new System.Drawing.Size(300, 21);
            this.cboFecha.TabIndex = 28;
            // 
            // BtnAgregarMiembro
            // 
            this.BtnAgregarMiembro.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.BtnAgregarMiembro.Location = new System.Drawing.Point(428, 136);
            this.BtnAgregarMiembro.Name = "BtnAgregarMiembro";
            this.BtnAgregarMiembro.Size = new System.Drawing.Size(59, 54);
            this.BtnAgregarMiembro.TabIndex = 27;
            this.BtnAgregarMiembro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAgregarMiembro.UseVisualStyleBackColor = true;
            this.BtnAgregarMiembro.Click += new System.EventHandler(this.BtnAgregarMiembro_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Fecha";
            // 
            // cbocanchas
            // 
            this.cbocanchas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocanchas.FormattingEnabled = true;
            this.cbocanchas.Location = new System.Drawing.Point(76, 102);
            this.cbocanchas.Name = "cbocanchas";
            this.cbocanchas.Size = new System.Drawing.Size(300, 21);
            this.cbocanchas.TabIndex = 31;
            // 
            // btnArgregarCanchas
            // 
            this.btnArgregarCanchas.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.btnArgregarCanchas.Location = new System.Drawing.Point(400, 78);
            this.btnArgregarCanchas.Name = "btnArgregarCanchas";
            this.btnArgregarCanchas.Size = new System.Drawing.Size(59, 54);
            this.btnArgregarCanchas.TabIndex = 30;
            this.btnArgregarCanchas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnArgregarCanchas.UseVisualStyleBackColor = true;
            this.btnArgregarCanchas.Click += new System.EventHandler(this.btnArgregarCanchas_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Canchas";
            // 
            // btnAgregarFecha
            // 
            this.btnAgregarFecha.Image = global::LaEquina.Windows.Properties.Resources.Mas;
            this.btnAgregarFecha.Location = new System.Drawing.Point(428, 196);
            this.btnAgregarFecha.Name = "btnAgregarFecha";
            this.btnAgregarFecha.Size = new System.Drawing.Size(59, 67);
            this.btnAgregarFecha.TabIndex = 32;
            this.btnAgregarFecha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarFecha.UseVisualStyleBackColor = true;
            this.btnAgregarFecha.Click += new System.EventHandler(this.btnAgregarFecha_Click);
            // 
            // cboMiembro
            // 
            this.cboMiembro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMiembro.FormattingEnabled = true;
            this.cboMiembro.Location = new System.Drawing.Point(104, 155);
            this.cboMiembro.Name = "cboMiembro";
            this.cboMiembro.Size = new System.Drawing.Size(300, 21);
            this.cboMiembro.TabIndex = 33;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmReservaAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 393);
            this.ControlBox = false;
            this.Controls.Add(this.cboMiembro);
            this.Controls.Add(this.btnAgregarFecha);
            this.Controls.Add(this.cbocanchas);
            this.Controls.Add(this.btnArgregarCanchas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboFecha);
            this.Controls.Add(this.BtnAgregarMiembro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTurno);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarHorario);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmReservaAE";
            this.Text = "FrmReservaAE";
            this.Load += new System.EventHandler(this.FrmReservaAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTurno;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregarHorario;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFecha;
        private System.Windows.Forms.Button BtnAgregarMiembro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbocanchas;
        private System.Windows.Forms.Button btnArgregarCanchas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregarFecha;
        private System.Windows.Forms.ComboBox cboMiembro;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}